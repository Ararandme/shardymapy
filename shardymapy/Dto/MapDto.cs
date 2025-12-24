using shardymapy.Models;
using shardymapy.Models.Naves;
using shardymapy.Models.Warehouse;

namespace shardymapy.Dto;

public class MapDto
{
    public int WarehouseId { get; set; }
    public IEnumerable<Warehouse>? Warehouses { get; set; }
    public IEnumerable<Nave>? Naves { get; set; }
}