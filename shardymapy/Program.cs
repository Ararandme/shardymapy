using Microsoft.EntityFrameworkCore;
using shardymapy.Data;
using shardymapy.Service;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MapyContext>(options => 
    options.UseMySql(builder.Configuration.GetConnectionString("cn"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("cn"))));
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<NaveServices>();
builder.Services.AddScoped<MapService>();
builder.Services.AddScoped<AnaquelService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.Logger.LogInformation("sup");

app.UseAuthorization();


app.MapStaticAssets();


app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();