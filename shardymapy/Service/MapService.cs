using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Dto.map;
using shardymapy.Models;
using shardymapy.Models.Anaquel;
using shardymapy.Models.Map;
using shardymapy.Models.Warehouse;

namespace shardymapy.Service;

public class MapService
{
    MapyContext _context;
    NaveServices _naveServices;
    private MapyContext _dbContext;
    public MapService(MapyContext context, NaveServices naveServices, MapyContext dbContext)
    {
        _context = context;
        _naveServices = naveServices;
        _dbContext = dbContext;
    }

    public async Task<List<MapListChecklistDto>?> GetChecklistDtosByWarehouseId(int? warehouseId)
    {
        var naves = await _naveServices.GetNavesByWarehouseId(warehouseId);
        List<MapListChecklistDto> dtos = [];

        foreach (var nave in naves)
        {
            dtos.Add(new MapListChecklistDto
            {
                NaveId = nave.Id
            });
        }

        return dtos;
    }

     public async Task GenerateAnaqueles(MapListDto form)
    {
        var anaquelDtos = form.CheckLists ?? new List<MapListChecklistDto>();

        var anaqueles = new List<Anaquel>();
        var celdas = new List<AnaquelLineaCelda>();
        var subceldas = new List<AnaquelLineaCeldasSubdivision>();

        int defaultSubCells = 1;

        foreach (var dto in anaquelDtos)
        {
            // skip unchecked rows
            if (!dto.Selected) continue;

            // Load Nave (include configuration because you need anaquelQuantity)
            var nave = await _context.Naves
                .Include(n => n.NaveConfiguration)
                .FirstOrDefaultAsync(n => n.Id == dto.NaveId);

            if (nave == null)
                throw new ArgumentException("Nave inválida");

            // Load configs
            var superiorConfig = await _context.AnaquelLineaVistaSuperiorConfiguracions
                .FirstOrDefaultAsync(x => x.Id == dto.SuperiorConfigId);

            if (superiorConfig == null)
                throw new ArgumentException("Superior config inválida");

            var frontalConfig = await _context.AnaquelLineaVistaFrontalConfigurations
                .FirstOrDefaultAsync(x => x.Id == dto.FrontalConfigId);

            if (frontalConfig == null)
                throw new ArgumentException("Frontal config inválida");

            // Create anaqueles per nave
            int anaquelQty = nave.NaveConfiguration?.AnaqueloQuantity ?? 0;
            if (anaquelQty <= 0) continue;

            var newAnaqueles = CreateAnaquelesPerNave(anaquelQty);

            // set anaquel configs + nave + index
            int aIndex = 1;
            foreach (var anaquel in newAnaqueles)
            {
                anaquel.AnaquelLineaVistaSuperiorConfiguracionId = superiorConfig.Id;
                anaquel.AnaquelLineaVistaFrontalConfigurationId = frontalConfig.Id;
                anaquel.NaveId = nave.Id;
                anaquel.AnaquelIndex = aIndex++;

                anaqueles.Add(anaquel);
            }

            int frontalColumns = frontalConfig.ColumnAmount;
            int frontalRows = frontalConfig.RowAmount;

            // create cells + subcells
            foreach (var anaquel in newAnaqueles)
            {
                for (int x = 0; x < frontalRows; x++)
                {
                    for (int y = 0; y < frontalColumns; y++)
                    {
                        var celda = new AnaquelLineaCelda
                        {
                            XPosition = x + 1,
                            YPosition = y + 1,
                            Anaquel = anaquel // navigation; EF will set FK when tracked
                        };

                        AddSubCells(defaultSubCells, celda, subceldas);
                        celdas.Add(celda);
                    }
                }
            }
        }

        // Save all atomically
        await using var tx = await _context.Database.BeginTransactionAsync();

        try
        {
            _dbContext.Anaquels.AddRange(anaqueles);
            _dbContext.AnaquelLineaCeldas.AddRange(celdas);
            _dbContext.AnaquelLineaCeldasSubdivisions.AddRange(subceldas);

            await _context.SaveChangesAsync();
            await tx.CommitAsync();
        }
        catch
        {
            await tx.RollbackAsync();
            throw;
        }
        
    }

    private List<Anaquel> CreateAnaquelesPerNave(int quantity)
    {
        var list = new List<Anaquel>(capacity: quantity);
        for (int i = 0; i < quantity; i++)
            list.Add(new Anaquel());
        return list;
    }

    private void AddSubCells(int count, AnaquelLineaCelda celda, List<AnaquelLineaCeldasSubdivision> subceldas)
    {
        for (int i = 1; i <= count; i++)
        {
            subceldas.Add(new AnaquelLineaCeldasSubdivision
            {
                AnaquelLineaCelda = celda, // navigation
                DivisionNumber = i
            });
        }
    }
    
    public async Task<List<PrintCodeList>> CreatePrintCode(int? warehouseId)
    {
        var exists = await _dbContext.Warehouses.AnyAsync(w => w.Id == warehouseId);
        if (!exists) throw new ArgumentException("Warehouse inválido");

        var mapList = await (
            from nave in _dbContext.Naves
            join anaquel in _dbContext.Anaquels on nave.Id equals anaquel.NaveId
            join celda in _dbContext.AnaquelLineaCeldas on anaquel.Id equals celda.AnaquelId
            join sub in _dbContext.AnaquelLineaCeldasSubdivisions on celda.Id equals sub.AnaquelLineaCeldaId
            where nave.WarehouseId == warehouseId
            select new PrintCodeList
            {
                WarehouseId = (int?)nave.WarehouseId,  
                NaveId = (int?)nave.Id,
                AnaquelId = anaquel.AnaquelIndex,
                AnaquelRowId = (int?)celda.XPosition,
                AnaquelColumnaId = (int?)celda.YPosition,
                AnaquelSubCeldaId = sub.Id
            }
        ).ToListAsync();

        return mapList;
    }
}
