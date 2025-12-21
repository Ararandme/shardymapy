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

    public async Task<Warehouse> GetWarehouseById(int id)
    {
        var warehouse = await _context.Warehouses.FindAsync((long) id);
        var warehouseConfiguration = await _context.WarehouseConfigurations
            .FirstOrDefaultAsync(n => n.WarehouseId == id);
        warehouse.WarehouseConfiguration = warehouseConfiguration;
        return warehouse;
    }
    
    public async Task<IEnumerable<Warehouse>> GetWarehouses()
    {
        IEnumerable <Warehouse> warehouses = await _context.Warehouses
            .Include(n => n.WarehouseConfiguration)
            .ToListAsync();

        return warehouses;
    }

    public async Task<bool> UpdateWarehouse(Warehouse warehouse)
    {
        _context.Warehouses.Update(warehouse);
        
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<bool> DeleteWarehouseById(int id)
    {
        
        
        var naveIds = await _context.Naves
            .Where(n => n.WarehouseId == id)
            .Select(n => n.Id)
            .ToListAsync();
        
       
        if (naveIds.Count > 0)
        {
            var naveConfigs = await _context.NaveConfigurations
                .Where(c => naveIds.Contains(c.NaveId))
                .ToListAsync();

            _context.NaveConfigurations.RemoveRange(naveConfigs);

            
            var naves = await _context.Naves
                .Where(n => n.WarehouseId == id)
                .ToListAsync();

            _context.Naves.RemoveRange(naves);
        }

        
        
        var config = await _context.WarehouseConfigurations
            .FirstOrDefaultAsync(n => n.WarehouseId == id);
        if (config != null) _context.WarehouseConfigurations.Remove(config);
        
        var warehouse =  await _context.Warehouses.FindAsync((long) id);
        if (warehouse != null)  _context.Warehouses.Remove(warehouse);
        
        return await _context.SaveChangesAsync() > 0;
        
    }
    

}