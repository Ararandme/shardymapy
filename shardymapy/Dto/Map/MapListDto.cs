using Microsoft.AspNetCore.Mvc.Rendering;
using shardymapy.Models.Anaquel;
using shardymapy.Models.Naves;
using shardymapy.Models.Warehouse;

namespace shardymapy.Dto.map;

public class MapListDto
{
    public int? WarehouseId { get; set; }
    public List<MapListChecklistDto>? CheckLists { get; set; } 
    public IEnumerable<Warehouse>? Warehouses { get; set; }
    public IEnumerable<Nave>? Naves { get; set; }
    public IEnumerable<SelectListItem>? SuperiorConfigs { get; set; }
    public IEnumerable<SelectListItem>? FrontalConfigs { get; set; }
    
}