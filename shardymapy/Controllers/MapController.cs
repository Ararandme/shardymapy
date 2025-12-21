using Microsoft.AspNetCore.Mvc;
using shardymapy.Dto;
using shardymapy.Service;

namespace shardymapy.Controllers;

public class MapController : Controller
{
    private readonly MapService _context;
    private readonly WarehouseService _warehouseService;
    private readonly NaveServices _naveServices;
    
    public MapController(MapService context,  WarehouseService warehouseService, NaveServices naveServices)
    {
        _naveServices = naveServices;
        _warehouseService = warehouseService;
        _context = context;
    }
    
    public async Task<IActionResult> MainMapView(int warehouseId)
    {
        var dto = new MapDto();
        var warehouses = await _context.GetWarehouses();
        dto.Warehouses = warehouses;

        if (warehouseId >= 0)
        {
            dto.Naves =  await _naveServices.GetNavesByWarehouseId(warehouseId);
        }
        
        
        return View(dto);
    }
    
}