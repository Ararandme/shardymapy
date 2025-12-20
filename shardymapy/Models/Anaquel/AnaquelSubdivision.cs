using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Keyless]
[Table("anaquel_subdivisions")]
[Index("AnaquelId", Name = "FKena8ecuwi1fm569wth6pw4fbc")]
[Index("SubdivisionsId", Name = "UK9s25thpnc1pyercpp4l33k6by", IsUnique = true)]
public partial class AnaquelSubdivision
{
    [Column("anaquel_id")]
    public int AnaquelId { get; set; }

    [Column("subdivisions_id")]
    public int SubdivisionsId { get; set; }

    [ForeignKey("AnaquelId")]
    public virtual Anaquel Anaquel { get; set; } = null!;

    [ForeignKey("SubdivisionsId")]
    public virtual AnaquelLineaCeldasSubdivision Subdivisions { get; set; } = null!;
}
