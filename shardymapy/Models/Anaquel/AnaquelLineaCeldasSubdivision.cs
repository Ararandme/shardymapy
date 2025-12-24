using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using shardymapy.Models.Items;

namespace shardymapy.Models.Anaquel;

[Table("anaquel_linea_celdas_subdivisions")]
public partial class AnaquelLineaCeldasSubdivision
{
    [Key]
    [Column("id")]
    public int Id { get; set; }


    [Column("division_number")]
    public double DivisionNumber { get; set; }

    
    public int AnaquelLineaCeldaId { get; set; }
    [ForeignKey(nameof(AnaquelLineaCeldaId))]
    public virtual AnaquelLineaCelda? AnaquelLineaCelda { get; set; }
 

    [ForeignKey("AnaquelSubdivionId")]
    [InverseProperty("AnaquelLineaCeldasSubdivision")]
    public virtual Sku? AnaquelSubdivion { get; set; }
}
