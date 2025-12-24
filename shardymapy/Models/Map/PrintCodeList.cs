namespace shardymapy.Models.Map;

public class PrintCodeList
{
    
    public int? WarehouseId { get; set; } = 0;
    public int? NaveId { get; set; } = 0;
    public int? AnaquelId { get; set; } = 0;
    public int? AnaquelColumnaId { get; set; } = 0;
    public int? AnaquelRowId { get; set; } = 0;
    public int? AnaquelSubCeldaId { get; set; } = 0;
    
    public string PrintCode =>
        $"{(WarehouseId ?? 0):D3}-" +
        $"{(NaveId ?? 0):D3}-" +
        $"{(AnaquelId ?? 0):D3}-" +
        $"{(AnaquelRowId ?? 0):D2}-" +
        $"{(AnaquelColumnaId ?? 0):D2}-" +
        $"{(AnaquelSubCeldaId ?? 0):D5}";

} 