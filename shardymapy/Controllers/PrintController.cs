using Microsoft.AspNetCore.Mvc;
using shardymapy.Dto.map;
using shardymapy.Service;

namespace shardymapy.Controllers;

public class PrintController : Controller
{
    WarehouseService _warehouseService;
    MapService _mapService;

    public PrintController(WarehouseService warehouseService, MapService mapService)
    {
        _warehouseService = warehouseService;
        _mapService = mapService;
    }


    public async Task<IActionResult> PrintMainView(int? warehouseId)
    {
        var dto = new PrintDto
        {
            Warehouses = await _warehouseService.GetWarehouses()
        };

        if (warehouseId.HasValue)
        {
            dto.PrintDtos =  await _mapService.CreatePrintCode(warehouseId);   
        }
             
        

        
        return View(dto);
    }
}