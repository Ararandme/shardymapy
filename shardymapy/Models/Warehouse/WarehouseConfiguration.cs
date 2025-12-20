using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("warehouse_configuration")]
[Index("WarehouseId", Name = "UKbhbni2qaobkr06qctw99wvce4", IsUnique = true)]
public partial class WarehouseConfiguration
{
    [Column("fecha_actualizacion")]
    public DateOnly? FechaActualizacion { get; set; }

    [Column("fecha_ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    [Column("heightz")]
    public double ?Heightz { get; set; }

    [Column("lenghtx")]
    public double ?Lenghtx { get; set; }

    [Column("widhty")]
    public double ?Widhty { get; set; }

    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("warehouse_id")]
    public long WarehouseId { get; set; }

    [ForeignKey("WarehouseId")]
    [InverseProperty("WarehouseConfiguration")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
