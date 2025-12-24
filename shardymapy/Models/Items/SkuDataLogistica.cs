
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using shardymapy.Models.Items;

namespace shardymapy.Models.Items;

[Table("sku_data_logistica")]
[Index("SkuId", Name = "UKmx6ncuh5obw78y8v0bmwl4dr8", IsUnique = true)]
public partial class SkuDataLogistica
{
    [Column("altura")]
    public double Altura { get; set; }

    [Column("ancho")]
    public double Ancho { get; set; }

    [Column("fecha_actualizacion")]
    public DateOnly? FechaActualizacion { get; set; }

    [Column("fecha_ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    [Column("largo")]
    public double Largo { get; set; }

    [Column("peso")]
    public double Peso { get; set; }

    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("sku_id")]
    public long? SkuId { get; set; }

    [Column("tipo")]
    [StringLength(255)]
    public string? Tipo { get; set; }

    [ForeignKey("SkuId")]
    [InverseProperty("SkuDataLogistica")]
    public virtual Sku? Sku { get; set; }
}
