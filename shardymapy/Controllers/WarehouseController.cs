using Microsoft.AspNetCore.Mvc;
using shardymapy.Data;
using shardymapy.Models;
using shardymapy.Models.Warehouse;
using shardymapy.Service;

namespace shardymapy.Controllers;

public class WarehouseController : Controller
{
    private readonly WarehouseService _service;
    
    public WarehouseController(WarehouseService service)
    {
        _service = service;

    }

    public async Task<IActionResult> MainWarehouseView()
    {
        var warehouses =  await _service.GetWarehouses();
        
        return  View(warehouses);
    }
    
    [HttpPost]
    public async Task<IActionResult> WarehouseForm([FromForm]Warehouse warehouse)
    {
     
        await _service.AddWarehouse(warehouse);
        return RedirectToAction("MainWarehouseView");
    }
    
    
    [HttpGet]
    public async Task<IActionResult> WarehouseEdit(int id)
    {
        return View(await _service.GetWarehouseById(id));
    }

    [HttpPost]
    public async Task<IActionResult> WarehouseEdit([FromForm] Warehouse warehouse)
    {
        await _service.UpdateWarehouse(warehouse);
        return RedirectToAction("MainWarehouseView");
    }
    
    public  async Task<IActionResult> WarehouseDelete(int id)
    {
        await _service.DeleteWarehouseById(id);
        return RedirectToAction("MainWarehouseView");
    }
    

   
    
}