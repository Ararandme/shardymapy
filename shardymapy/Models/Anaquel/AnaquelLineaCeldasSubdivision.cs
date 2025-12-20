using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("anaquel_linea_celdas_subdivisions")]
[Index("AnaquelId", Name = "FKfonl2cesdf3eedhnv2623g3vn")]
[Index("AnaquelSubdivionId", Name = "UKcv25nq0b25xqmeq3i08h6l7os", IsUnique = true)]
public partial class AnaquelLineaCeldasSubdivision
{
    [Column("anaquel_id")]
    public int? AnaquelId { get; set; }

    [Column("division_number")]
    public double DivisionNumber { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("anaquel_subdivion_id")]
    public long AnaquelSubdivionId { get; set; }

    [ForeignKey("AnaquelId")]
    [InverseProperty("AnaquelLineaCeldasSubdivisions")]
    public virtual Anaquel? Anaquel { get; set; }

    [ForeignKey("AnaquelSubdivionId")]
    [InverseProperty("AnaquelLineaCeldasSubdivision")]
    public virtual Sku AnaquelSubdivion { get; set; } = null!;
}
