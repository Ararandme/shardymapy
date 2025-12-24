using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models.Anaquel;

[Table("anaquel_linea_vista_superior_configuracion")]
[Index("ConfigNombre", IsUnique = true)]

public partial class AnaquelLineaVistaSuperiorConfiguracion
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public required string ConfigNombre { get; set; }

    [Column("column_separation_width")]
    public double ColumnSeparationWidth { get; set; }

    [Column("middle_padding_size")]
    public double MiddlePaddingSize { get; set; }

    [Column("anaquel_block_amountx")]
    public double AnaquelBlockAmountx { get; set; }

    [Column("anaquel_block_amounty")]
    public double AnaquelBlockAmounty { get; set; }

    [Column("anaquel_block_heighty")]
    public double AnaquelBlockHeighty { get; set; }

    [Column("anaquel_block_widhtx")]
    public double AnaquelBlockWidhtx { get; set; }

    [Column("anaquel_total_widthx")]
    public double AnaquelTotalWidthx { get; set; }

    
 
    [InverseProperty("AnaquelLineaVistaSuperiorConfiguracion")]
    public virtual IEnumerable<Anaquel> AnaquelSupconfig { get; set; } = null!;
}
