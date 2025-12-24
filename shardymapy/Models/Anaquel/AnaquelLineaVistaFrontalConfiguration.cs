using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models.Anaquel;

[Table("anaquel_linea_vista_frontal_configuration")]
[Index("ConfigNombre", IsUnique = true)]
public partial class AnaquelLineaVistaFrontalConfiguration
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string ConfigNombre { get; set; }

    [Column("total_widthx")]
    public double TotalWidthx { get; set; }

    [Column("total_heighty")]
    public double TotalHeighty { get; set; }

    [Column("block_heighty")]
    public double BlockHeighty { get; set; }

    [Range(1, 50)] 
    public int ColumnAmount { get; set; } = 1;
    
    [Range(1, 50)] 
    public int RowAmount { get; set; } = 1;
    
    
    [InverseProperty("AnaquelLineaVistaFrontalConfiguration")]
    public virtual IEnumerable<Anaquel> AnaquelFrontalconfig { get; set; } = null!;
}
