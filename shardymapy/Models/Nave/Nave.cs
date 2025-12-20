using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("nave")]
[Index("WarehouseId", Name = "FKisya2y7ihhv5cv82icglsfqry")]
public partial class Nave
{
    [Column("estado", TypeName = "bit(1)")]
    public bool Estado { get; set; }

    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("warehouse_id")]
    public long WarehouseId { get; set; }

    [Column("nave_alias")]
    [StringLength(255)]
    public string NaveAlias { get; set; } = null!;

    [InverseProperty("Nave")]
    public virtual ICollection<Anaquel> Anaquels { get; set; } = new List<Anaquel>();

    [InverseProperty("Nave")]
    public virtual NaveConfiguration? NaveConfiguration { get; set; }

    [ForeignKey("WarehouseId")]
    [InverseProperty("Naves")]
    public virtual Warehouse? Warehouse { get; set; } = null!;
}
