using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Models;
using shardymapy.Models.User;

namespace shardymapy.Controllers;

public class UserController : Controller
{
    private readonly MapyContext _context;

    public UserController(MapyContext context)
    {
        _context = context;
    } 

    [HttpGet]
    public async Task<IActionResult> MainUserView()
    {
        IEnumerable<User> users = await  _context.Users
            .Include(u => u.UserProfile)
            .ToListAsync();
        
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] User user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("MainUserView");
    }
}