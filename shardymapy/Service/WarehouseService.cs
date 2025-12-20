using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Models;

namespace shardymapy.Service;

public class WarehouseService
{
    private ArarContext _context;
    public WarehouseService(ArarContext context)
    {
        _context = context;
    }
    
    
    public async Task<bool> AddWarehouse(Warehouse warehouse)
    {
        
        if (warehouse == null) return false;
        _context.Warehouses.Add(warehouse);
        int value  = await _context.SaveChangesAsync();
  

        return value > 0; 
    }
    
    public async Task<IEnumerable<Warehouse>> GetWarehouses()
    {
        IEnumerable <Warehouse> warehouses = await _context.Warehouses.ToListAsync();

        return warehouses;
    }
    
    
}