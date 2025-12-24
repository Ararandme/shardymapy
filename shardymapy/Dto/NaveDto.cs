using shardymapy.Models;
using shardymapy.Models.Naves;
using shardymapy.Models.Warehouse;

namespace shardymapy.Dto;

public class NaveDto
{
    public IEnumerable<Warehouse>? Warehouses { get; set; }
    public IEnumerable<Nave>? Naves { get; set; }
    public Nave? Nave { get; set; }


}