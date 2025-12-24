using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Models;
using shardymapy.Models.Items;

namespace shardymapy.Controllers;

public class ItemController : Controller
{
    MapyContext _context;
    
    public ItemController(MapyContext context)
    {
        _context = context;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> MainItemView()
    {
        IEnumerable<Sku> skus = await _context.Skus
            .Include(s => s.SkuDataLogistica)
            .ToListAsync();
        
        return View(skus);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm]Sku sku)
    {
    
        
            _context.Skus.Add(sku);
            await _context.SaveChangesAsync();
        
        return RedirectToAction("MainItemView");
    }
    
}