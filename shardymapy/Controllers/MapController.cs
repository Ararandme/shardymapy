using Microsoft.AspNetCore.Mvc;
using shardymapy.Dto;
using shardymapy.Dto.map;
using shardymapy.Models.Anaquel;
using shardymapy.Service;

namespace shardymapy.Controllers;

public class MapController : Controller
{
    private readonly MapService _context;
    private readonly WarehouseService _warehouseService;
    private readonly NaveServices _naveServices;
    private readonly AnaquelService _anaquelServices;

    
    public MapController(MapService context,  WarehouseService warehouseService, NaveServices naveServices, AnaquelService anaquelServices)
    {
        _naveServices = naveServices;
        _anaquelServices = anaquelServices;
        _warehouseService = warehouseService;
        _context = context;
    }
    
    public async Task<IActionResult> MainMapView(int warehouseId)
    {
        var dto = new MapDto();
        var warehouses = await _warehouseService.GetWarehouses();
        dto.Warehouses = warehouses;

        if (warehouseId >= 0)
        {
            dto.Naves =  await _naveServices.GetNavesByWarehouseId(warehouseId);
            
        }
        
        
        return View(dto);
    }
    
    public async Task<IActionResult> MapListGeneratorForm(int? warehouseId)
    {
      
        var  dto = new MapListDto
        {
          
            Warehouses = await _warehouseService.GetWarehouses(),
            FrontalConfigs = await _anaquelServices.GetFrontalConfigurationsSelected(),
            SuperiorConfigs = await _anaquelServices.GetSuperiorConfigurationsSelected()
        };

        if (warehouseId != null)
        {
            dto.WarehouseId = warehouseId;
            dto.Naves = await _naveServices.GetNavesByWarehouseId(warehouseId);
            dto.CheckLists = await _context.GetChecklistDtosByWarehouseId(warehouseId);
        }
        
          
        
    
        Console.Out.WriteLine("myid" + warehouseId);
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> MapListGeneratorSave(MapListDto dto)
    {
        await _context.GenerateAnaqueles(dto);
        return RedirectToAction(nameof(MapListGeneratorForm));
    }
    
    
}