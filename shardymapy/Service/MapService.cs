using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Models;

namespace shardymapy.Service;

public class MapService
{
    ArarContext _context;
    public MapService(ArarContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Warehouse>> GetWarehouses()
    {
        return await _context.Warehouses.ToListAsync();
    }
    
    
}