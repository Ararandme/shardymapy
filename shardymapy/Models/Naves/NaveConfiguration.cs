using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models.Naves;

[Table("nave_configuration")]
[Index("NaveId", Name = "UK1ikryuv8a2t22v7jqpwqy347e", IsUnique = true)]
public partial class NaveConfiguration
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("lenghtx")]
    public double Lenghtx { get; set; }

    [Column("widthy")]
    public double Widthy { get; set; }

    [Column("heightz")]
    public double Heightz { get; set; }

    [Column("margin_size_bottony")]
    public double MarginSizeBottony { get; set; }

    [Column("margin_size_leftx")]
    public double MarginSizeLeftx { get; set; }

    [Column("margin_size_rightx")]
    public double MarginSizeRightx { get; set; }

    [Column("margin_size_topy")]
    public double MarginSizeTopy { get; set; }

    [Column("pasillo_width")]
    public double PasilloWidth { get; set; }

    [Column("pasillo_quantity")]
    public int PasilloQuantity { get; set; }
    
    [Column("anaquel_quantity")]
    public int AnaqueloQuantity { get; set; }

    [Column("fecha_actualzicion")]
    public DateOnly? FechaActualzicion { get; set; }

    [Column("fecha_ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    [Column("nave_id")]
    public long NaveId { get; set; }

    [ForeignKey("NaveId")]
    [InverseProperty("NaveConfiguration")]
    public virtual Nave Nave { get; set; } = null!;
}
