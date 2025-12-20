using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("sku_kardex")]
[Index("SkuId", Name = "FKtdtgex1c1dh4hsaw98yy7i1jp")]
public partial class SkuKardex
{
    [Column("cantidad_ingreso")]
    public int CantidadIngreso { get; set; }

    [Column("fecha_ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    [Column("fecha_salida")]
    public DateOnly? FechaSalida { get; set; }

    [Column("hora_ingreso")]
    public DateOnly? HoraIngreso { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sku_id")]
    public long? SkuId { get; set; }

    [Column("cantidad_salida")]
    [StringLength(255)]
    public string? CantidadSalida { get; set; }

    [Column("en_uso_por_usuario")]
    [StringLength(255)]
    public string? EnUsoPorUsuario { get; set; }

    [Column("hora_salida")]
    [StringLength(255)]
    public string? HoraSalida { get; set; }

    [ForeignKey("SkuId")]
    [InverseProperty("SkuKardices")]
    public virtual Sku? Sku { get; set; }
}
