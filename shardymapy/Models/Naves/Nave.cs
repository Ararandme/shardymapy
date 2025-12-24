using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models.Naves;

[Table("nave")]
[Index("WarehouseId", Name = "FKisya2y7ihhv5cv82icglsfqry")]
public class Nave
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("nave_alias")]
    [StringLength(255)]
    public string NaveAlias { get; set; } = null!;

    [Column("estado", TypeName = "bit(1)")]
    public bool Estado { get; set; }

    [InverseProperty("Nave")]
    public virtual NaveConfiguration? NaveConfiguration { get; set; }

    [Column("warehouse_id")]
    public long WarehouseId { get; set; }

    [ForeignKey(nameof(WarehouseId))]
    [InverseProperty("Naves")]
    public virtual Warehouse.Warehouse? Warehouse { get; set; } = null!;

    [InverseProperty("Nave")]
    public virtual ICollection<Anaquel.Anaquel> Anaquels { get; set; } = new List<Anaquel.Anaquel>();
}
