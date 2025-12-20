using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("anaquel")]
[Index("NaveId", Name = "FKc3qdvxqm7wty5v4wnlwb51r3t")]
public partial class Anaquel
{
    [Column("anaquel_index")]
    public int AnaquelIndex { get; set; }

    [Column("estado", TypeName = "bit(1)")]
    public ulong Estado { get; set; }

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nave_id")]
    public long? NaveId { get; set; }

    [InverseProperty("Anaquel")]
    public virtual ICollection<AnaquelLineaCelda> AnaquelLineaCelda { get; set; } = new List<AnaquelLineaCelda>();

    [InverseProperty("Anaquel")]
    public virtual ICollection<AnaquelLineaCeldasSubdivision> AnaquelLineaCeldasSubdivisions { get; set; } = new List<AnaquelLineaCeldasSubdivision>();

    [InverseProperty("AnaquelFrontalconfig")]
    public virtual AnaquelLineaVistaFrontalConfiguration? AnaquelLineaVistaFrontalConfiguration { get; set; }

    [InverseProperty("AnaquelSupconfig")]
    public virtual AnaquelLineaVistaSuperiorConfiguracion? AnaquelLineaVistaSuperiorConfiguracion { get; set; }

    [ForeignKey("NaveId")]
    [InverseProperty("Anaquels")]
    public virtual Nave? Nave { get; set; }
}
