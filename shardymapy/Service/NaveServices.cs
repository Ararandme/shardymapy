using System.Collections;
using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Dto;
using shardymapy.Models;
using shardymapy.Models.Naves;
using shardymapy.Models.Warehouse;

namespace shardymapy.Service;

public class NaveServices
{
    private readonly MapyContext _context ;

    public NaveServices(MapyContext context)
    {
        _context = context;
    }
    
    public MapyContext MapyContext
    {
        get
        {
            return _context;
        }
    }

    public async Task<IEnumerable<Nave>> GetNaves()
    {
        var naves = await _context.Naves.Include(n => 
            n.NaveConfiguration).ToListAsync();
        return naves;
    }
  


    public async Task<bool> AddnaveWithDto(NaveDto dto)
    {
        if (dto == null) return false;
        var nave = dto.Nave;
        nave?.Warehouse =  await _context.Warehouses.FindAsync(nave.Warehouse.Id);
       
        
        _context.Naves.Add(nave);
        int value  = await _context.SaveChangesAsync();
  

        return value > 0; 
    }

    public async Task<NaveDto> GetNaveDtoByNaveId(int id)
    {
        var dto = new NaveDto();
        dto.Nave = await _context.Naves.FindAsync((long) id);
        dto.Nave?.NaveConfiguration = await _context.NaveConfigurations
            .FirstOrDefaultAsync(n =>n.NaveId == id );

        return dto;
    }

    public async Task<IEnumerable<Nave>> GetNavesByWarehouseId(int? id)
    {
        var naves = await _context.Naves
            .Where(n => n.WarehouseId == id)
            .Include(n => n.NaveConfiguration)
            .ToListAsync();
        return naves;
    }

    public async Task<bool> updateNaveByDto(NaveDto dto)
    {
          var nave  = dto.Nave;
          nave?.Warehouse = await _context.Warehouses.FindAsync(nave.Warehouse?.Id);
          _context.Naves.Update(dto.Nave);
          return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteNaveByNaveId(int id)
    {
        var config= await _context.NaveConfigurations.FirstOrDefaultAsync(n => 
            n.NaveId == id);
        if (config != null) _context.NaveConfigurations.Remove(config);

        var nave  = await _context.Naves.FindAsync((long) id);
        if (nave == null) return false;
        
        _context.Naves.Remove(nave);
        return await _context.SaveChangesAsync() > 0;
    }
 
    
}