using Microsoft.AspNetCore.Mvc;
using shardymapy.Dto;
using shardymapy.Models.Anaquel;
using shardymapy.Service;

namespace shardymapy.Controllers;

public class AnaquelController : Controller
{
    private readonly AnaquelService _anaquelService;

    public AnaquelController(AnaquelService anaquelService)
    {
        _anaquelService = anaquelService;
    }

    public async Task<IActionResult> AnaquelConfigMainView()
    {
        AnaquelConfigDto dto = new AnaquelConfigDto();
        dto.FrontalConfiguration = new AnaquelLineaVistaFrontalConfiguration {ConfigNombre = ""};
        dto.SuperiorConfiguration = new AnaquelLineaVistaSuperiorConfiguracion {ConfigNombre = "" };
        dto.FrontalConfigurations = await _anaquelService.GetFrontalConfigurations();
        dto.SuperiorConfigurations = await _anaquelService.GetSuperiorConfigurations();
        
        return View(dto);
    }
    
    //create
    [HttpPost]
    public async Task<IActionResult> FrontalConfigSave([FromForm]AnaquelConfigDto config)
    {
        await _anaquelService.SaveFrontalConfigFromDto(config);
        
        return RedirectToAction(nameof(AnaquelConfigMainView));
    }
    
    [HttpPost]
    public async Task<IActionResult> SuperiorConfigSave([FromForm]AnaquelConfigDto config)
    {
        await _anaquelService.SaveSuperiorConfigFromDto(config);
        return RedirectToAction(nameof(AnaquelConfigMainView));
    }

    
    //update
    [HttpGet]
    public async Task<IActionResult> FrontalConfigUpdate(int id)
    {
        return View(await _anaquelService.GetFrontalConfiguration(id));
    }
    [HttpPost]
    public async Task<IActionResult> FrontalConfigUpdate([FromForm] AnaquelLineaVistaFrontalConfiguration  config)
    {
        await _anaquelService.UpdateFrontalConfigFromDto(config);
        return RedirectToAction(nameof(AnaquelConfigMainView));
    }
    
    
    [HttpGet]
    public async Task<IActionResult> SuperiorConfigUpdate(int id)
    {
        return View(await _anaquelService.GetSuperiorConfiguration(id));
    }
    [HttpPost]
    public async Task<IActionResult> SuperiorConfigUpdate([FromForm]AnaquelLineaVistaSuperiorConfiguracion  config)
    {
        await _anaquelService.UpdateSuperiorConfigFromDto(config);
        return RedirectToAction(nameof(AnaquelConfigMainView));
    }

    
    
    //delete
    [HttpGet]
    public async Task<IActionResult> SuperiorConfigDelete(int id)
    {
        await _anaquelService.DeleteSuperiorConfigFromId(id);
        return RedirectToAction(nameof(AnaquelConfigMainView));
    }

    [HttpGet]
    public async Task<IActionResult> FrontalConfigDelete(int id)
    {
        await _anaquelService.DeleteFrontalConfigFromId(id);
        return RedirectToAction(nameof(AnaquelConfigMainView));
    }
}