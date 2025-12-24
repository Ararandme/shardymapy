using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models.Anaquel;

[Table("anaquel_linea_celdas")]
public class AnaquelLineaCelda
{
    [Key]
    [Column("id")]
    public int Id { get; set; }


    [Column("x_position")]
    public double XPosition { get; set; }

    [Column("y_position")]
    public double YPosition { get; set; }

    [Column("anaquel_id")]
    public int? AnaquelId { get; set; }

    [ForeignKey(nameof(AnaquelId))]
    [InverseProperty("AnaquelLineaCelda")]
    public virtual Anaquel? Anaquel { get; set; }
    
    
    public virtual List<AnaquelLineaCeldasSubdivision>? AnaquelLineaCeldasSubdivision { get; set; }
}
