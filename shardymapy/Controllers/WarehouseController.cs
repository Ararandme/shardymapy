using Microsoft.AspNetCore.Mvc;
using shardymapy.Data;
using shardymapy.Models;
using shardymapy.Service;

namespace shardymapy.Controllers;

public class WarehouseController : Controller
{
    private readonly WarehouseService _service;
    
    public WarehouseController(WarehouseService service)
    {
        _service = service;

    }

    public IActionResult WarehouseForm()
    {
        var warehouse = new Warehouse();
    
        
        return  View(warehouse);
    }
    
    [HttpPost]
    public async Task<IActionResult> WarehouseForm([FromForm]Warehouse warehouse)
    {
     
        await _service.AddWarehouse(warehouse);
        return RedirectToAction("WarehouseForm");
    }
    
}