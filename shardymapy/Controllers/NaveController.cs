using Microsoft.AspNetCore.Mvc;
using shardymapy.Dto;
using shardymapy.Models.Naves;
using shardymapy.Service;

namespace shardymapy.Controllers;

public class NaveController : Controller
{
    NaveServices _service;
    WarehouseService _warehouseService;

    public NaveController(NaveServices service, WarehouseService warehouseService)
    {
        _service = service;
        _warehouseService = warehouseService;
    }
    
    
    public async Task<IActionResult> NaveDashboard()
    {
        var dto = new NaveDto();
        dto.Warehouses = await _warehouseService.GetWarehouses();
        dto.Nave = new Nave();
        dto.Naves = await _service.GetNaves();
        return View(dto);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] NaveDto naveDto)
    {
        await _service.AddnaveWithDto(naveDto);
        return RedirectToAction("NaveDashboard");
    }

    [HttpGet]
    public async Task<IActionResult> NaveEdit([FromRoute]int id)
    {
        var dto = await _service.GetNaveDtoByNaveId(id);
        dto.Warehouses = await _warehouseService.GetWarehouses();
        
        return View(dto);
    }
    [HttpPost]
    public async Task<IActionResult> NaveEdit([FromForm]NaveDto naveDto)
    {
        await _service.updateNaveByDto(naveDto);
        
        return RedirectToAction("NaveDashboard");
    }
    [HttpGet]
    public async Task<IActionResult> NaveDelete(int id)
    {
        await _service.DeleteNaveByNaveId(id);
        return RedirectToAction("NaveDashboard");
    }
}