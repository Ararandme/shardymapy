using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using shardymapy.Models.Anaquel;

namespace shardymapy.Models.Items;

[Table("sku")]
public partial class Sku
{
    [Column("estado", TypeName = "bit(1)")]
    public bool Estado { get; set; }

    [Column("fecha_ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("descripcion")]
    [StringLength(255)]
    public string? Descripcion { get; set; }

    [Column("thumbnail")]
    [StringLength(255)]
    public string? Thumbnail { get; set; }

    [InverseProperty("AnaquelSubdivion")]
    public virtual AnaquelLineaCeldasSubdivision? AnaquelLineaCeldasSubdivision { get; set; }

    [InverseProperty("Sku")]
    public virtual SkuDataLogistica? SkuDataLogistica { get; set; }
    
    public IEnumerable<Sku>? Skus { get; set; }

   
}
