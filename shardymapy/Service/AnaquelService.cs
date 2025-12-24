using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Dto;
using shardymapy.Models.Anaquel;

namespace shardymapy.Service;

public class AnaquelService
{
    private readonly MapyContext _context;
    
    public AnaquelService(MapyContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<AnaquelLineaVistaFrontalConfiguration>> GetFrontalConfigurations()
    {
        return await _context.AnaquelLineaVistaFrontalConfigurations.ToListAsync();
    } 
    public async Task<IEnumerable<SelectListItem>> GetFrontalConfigurationsSelected()
    {
        var list = await _context.AnaquelLineaVistaFrontalConfigurations.ToListAsync();
        IEnumerable<SelectListItem> items =
            from item in list
            select new SelectListItem
            {
                Value =  item.Id.ToString(),
                Text = item.ConfigNombre
            };
        return items;
       
    }
    public async Task<IEnumerable<AnaquelLineaVistaSuperiorConfiguracion>> GetSuperiorConfigurations()
    {
        return await _context.AnaquelLineaVistaSuperiorConfiguracions.ToListAsync();
    }
    public async Task<IEnumerable<SelectListItem>> GetSuperiorConfigurationsSelected()
    {
        var list = await _context.AnaquelLineaVistaSuperiorConfiguracions.ToListAsync();
        IEnumerable<SelectListItem> items =
            from item in list
            select new SelectListItem
            {
                Value =  item.Id.ToString(),
                Text = item.ConfigNombre
            };
        return items;
       
    }

    public async Task<AnaquelLineaVistaFrontalConfiguration?> GetFrontalConfiguration(int id)
    {
        return await _context.AnaquelLineaVistaFrontalConfigurations.FindAsync(id);
    }
    public async Task<AnaquelLineaVistaSuperiorConfiguracion?> GetSuperiorConfiguration(int id)
    {
        return await _context.AnaquelLineaVistaSuperiorConfiguracions.FindAsync(id);
    }
    
    public async Task<int> SaveFrontalConfigFromDto(AnaquelConfigDto dto)
    {
        var config = dto.FrontalConfiguration;
        if (config == null) return 0;
        
        _context.AnaquelLineaVistaFrontalConfigurations.Add(config);
        int result = await _context.SaveChangesAsync();
        return result;
    }
    public async Task<int> SaveSuperiorConfigFromDto(AnaquelConfigDto dto)
    {
        var config = dto.SuperiorConfiguration;
        if (config == null) return 0;
        
        _context.AnaquelLineaVistaSuperiorConfiguracions.Add(config);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateFrontalConfigFromDto(AnaquelLineaVistaFrontalConfiguration config)
    {
       
        _context.AnaquelLineaVistaFrontalConfigurations.Update(config);
        return await _context.SaveChangesAsync();
    }
    public async Task<int> UpdateSuperiorConfigFromDto(AnaquelLineaVistaSuperiorConfiguracion config)
    {
        _context.AnaquelLineaVistaSuperiorConfiguracions.Update(config);
        return await _context.SaveChangesAsync();
    }
    
    

    public async Task<int> DeleteFrontalConfigFromId(int id)
    {
        var  config = await _context.AnaquelLineaVistaFrontalConfigurations.FindAsync(id);
        if (config == null) return 0;
        _context.AnaquelLineaVistaFrontalConfigurations.Remove(config);
       return await _context.SaveChangesAsync();
    }
    public async Task<int> DeleteSuperiorConfigFromId(int id)
    {
        var  config = await _context.AnaquelLineaVistaSuperiorConfiguracions.FindAsync(id);
        if (config == null) return 0;
        _context.AnaquelLineaVistaSuperiorConfiguracions.Remove(config);
        return  await _context.SaveChangesAsync();
    }

   
    
}