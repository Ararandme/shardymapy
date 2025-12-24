using shardymapy.Models.Map;
using shardymapy.Models.Warehouse;

namespace shardymapy.Dto.map;

public class PrintDto
{
    public IEnumerable<Warehouse>?  Warehouses { get; set; }
    public List<PrintCodeList>? PrintDtos { get; set; }
}