using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models.Warehouse;

[Table("warehouse_configuration")]
[Index("WarehouseId", Name = "UKbhbni2qaobkr06qctw99wvce4", IsUnique = true)]
public partial class WarehouseConfiguration
{
    
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("lenghtx")]
    public double ?Lenghtx { get; set; }

    [Column("widhty")]
    public double ?Widhty { get; set; }

    [Column("heightz")]
    public double ?Heightz { get; set; }

    [Column("fecha_ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    [Column("fecha_actualizacion")]
    public DateOnly? FechaActualizacion { get; set; }


    [Column("warehouse_id")]
    public long WarehouseId { get; set; }

    [ForeignKey(nameof(WarehouseId))]
    [InverseProperty("WarehouseConfiguration")]
    public virtual Models.Warehouse.Warehouse Warehouse { get; set; } = null!;
}
