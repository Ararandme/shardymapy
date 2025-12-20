using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Models;

namespace shardymapy.Controllers;

public class ItemController : Controller
{
    ArarContext _context;
    
    public ItemController(ArarContext context)
    {
        _context = context;
    }
    
    
    public async Task<IActionResult> MainItemView()
    {
        IEnumerable<Sku> skus = await _context.Skus
            .Include(s => s.SkuDataLogistica)
            .ToListAsync();
        
        return View(skus);
    }

    public async Task<IActionResult> Create([FromForm]Sku sku)
    {
        if (ModelState.IsValid)
        {
            _context.Skus.Add(sku);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("MainItemView");
    }
    
}