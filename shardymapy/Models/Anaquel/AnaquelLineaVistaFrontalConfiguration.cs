using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("anaquel_linea_vista_frontal_configuration")]
[Index("AnaquelFrontalconfigId", Name = "UKl1b27i9cwasgekusf4gs6d7fr", IsUnique = true)]
public partial class AnaquelLineaVistaFrontalConfiguration
{
    [Column("anaquel_frontalconfig_id")]
    public int AnaquelFrontalconfigId { get; set; }

    [Column("block_heighty")]
    public double BlockHeighty { get; set; }

    [Column("fecha_actualizacion")]
    public DateOnly? FechaActualizacion { get; set; }

    [Column("fecha_ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("total_heighty")]
    public double TotalHeighty { get; set; }

    [Column("total_widthx")]
    public double TotalWidthx { get; set; }

    [ForeignKey("AnaquelFrontalconfigId")]
    [InverseProperty("AnaquelLineaVistaFrontalConfiguration")]
    public virtual Anaquel AnaquelFrontalconfig { get; set; } = null!;
}
