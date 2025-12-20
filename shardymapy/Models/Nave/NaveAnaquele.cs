using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Keyless]
[Table("nave_anaqueles")]
[Index("NaveId", Name = "FK1lelktpo3yrw3i43cf0sqp5ur")]
[Index("AnaquelesId", Name = "UK5fkxepdtbb52vbbxepqd9w3wh", IsUnique = true)]
public partial class NaveAnaquele
{
    [Column("anaqueles_id")]
    public int AnaquelesId { get; set; }

    [Column("nave_id")]
    public long NaveId { get; set; }

    [ForeignKey("AnaquelesId")]
    public virtual Anaquel Anaqueles { get; set; } = null!;

    [ForeignKey("NaveId")]
    public virtual Nave Nave { get; set; } = null!;
}
