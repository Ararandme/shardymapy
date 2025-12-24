using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using shardymapy.Models.Naves;

namespace shardymapy.Models.Anaquel;

[Table("anaquel")]
[Index("NaveId", Name = "FKc3qdvxqm7wty5v4wnlwb51r3t")]
public class Anaquel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("anaquel_index")]
    public int AnaquelIndex { get; set; }

    [Column("estado", TypeName = "bit(1)")]
    public ulong Estado { get; set; }

    [Column("nave_id")]
    public long? NaveId { get; set; }

    [ForeignKey(nameof(NaveId))]
    [InverseProperty("Anaquels")]
    public virtual Nave? Nave { get; set; }

    public int AnaquelLineaVistaFrontalConfigurationId { get; set; }
    [ForeignKey(nameof(AnaquelLineaVistaFrontalConfigurationId))]
    [InverseProperty("AnaquelFrontalconfig")]
    public virtual AnaquelLineaVistaFrontalConfiguration? AnaquelLineaVistaFrontalConfiguration { get; set; }

    public int AnaquelLineaVistaSuperiorConfiguracionId { get; set; }
    [ForeignKey(nameof(AnaquelLineaVistaSuperiorConfiguracionId))]
    [InverseProperty("AnaquelSupconfig")]
    public virtual AnaquelLineaVistaSuperiorConfiguracion? AnaquelLineaVistaSuperiorConfiguracion { get; set; }

    [InverseProperty("Anaquel")]
    public virtual ICollection<AnaquelLineaCelda> AnaquelLineaCelda { get; set; } = new List<AnaquelLineaCelda>();
    
}
