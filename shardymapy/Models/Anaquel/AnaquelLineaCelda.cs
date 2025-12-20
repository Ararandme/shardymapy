using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("anaquel_linea_celdas")]
[Index("AnaquelId", Name = "FK2qeq8vffs4ri8u0xqgeqjia9a")]
public partial class AnaquelLineaCelda
{
    [Column("anaquel_id")]
    public int? AnaquelId { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("x_position")]
    public double XPosition { get; set; }

    [Column("y_position")]
    public double YPosition { get; set; }

    [ForeignKey("AnaquelId")]
    [InverseProperty("AnaquelLineaCelda")]
    public virtual Anaquel? Anaquel { get; set; }
}
