using System.Collections;
using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Dto;
using shardymapy.Models;

namespace shardymapy.Service;

public class NaveServices
{
    private readonly ArarContext _context ;

    public NaveServices(ArarContext context)
    {
        _context = context;
    }
    
    public ArarContext ArarContext
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

        return dto;
    }

    public async Task<bool> updateNaveByDto(NaveDto dto)
    {
          var nave  = dto.Nave;
          nave?.Warehouse = await _context.Warehouses.FindAsync(nave.Warehouse?.Id);
          _context.Naves.Update(dto.Nave);
          return await _context.SaveChangesAsync() > 0;
    }
 
    
}