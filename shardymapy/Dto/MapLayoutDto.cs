using shardymapy.Models.Anaquel;
using shardymapy.Models.Map;
using shardymapy.Models.Naves;

namespace shardymapy.Dto;

public class MapLayoutDto
{
    IEnumerable<Nave> naves { get; set; }
    IEnumerable<Anaquel> anaqueles { get; set; }
    
}