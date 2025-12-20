using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("anaquel_linea_vista_superior_configuracion")]
[Index("AnaquelSupconfigId", Name = "UK8g50nfs7g7bps2iu5che7aeeo", IsUnique = true)]
public partial class AnaquelLineaVistaSuperiorConfiguracion
{
    [Column("anaquel_block_amountx")]
    public double AnaquelBlockAmountx { get; set; }

    [Column("anaquel_block_amounty")]
    public double AnaquelBlockAmounty { get; set; }

    [Column("anaquel_block_heighty")]
    public double AnaquelBlockHeighty { get; set; }

    [Column("anaquel_block_widhtx")]
    public double AnaquelBlockWidhtx { get; set; }

    [Column("anaquel_supconfig_id")]
    public int AnaquelSupconfigId { get; set; }

    [Column("anaquel_total_widthx")]
    public double AnaquelTotalWidthx { get; set; }

    [Column("column_separation_width")]
    public double ColumnSeparationWidth { get; set; }

    [Column("fecha_actualizacion")]
    public DateOnly? FechaActualizacion { get; set; }

    [Column("fecha_ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("middle_padding_size")]
    public double MiddlePaddingSize { get; set; }

    [ForeignKey("AnaquelSupconfigId")]
    [InverseProperty("AnaquelLineaVistaSuperiorConfiguracion")]
    public virtual Anaquel AnaquelSupconfig { get; set; } = null!;
}
