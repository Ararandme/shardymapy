using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("warehouse")]
[Index("WarehouseAlias", Name = "UKh0lba73ewb07o3iu1367h2d8m", IsUnique = true)]
public partial class Warehouse
{
    [Column("estado", TypeName = "bit(1)")]
    public ulong Estado { get; set; }

    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("warehouse_alias")]
    [StringLength(20)]
    public string WarehouseAlias { get; set; } = null!;

    [InverseProperty("Warehouse")]
    public virtual ICollection<Nave> Naves { get; set; } = new List<Nave>();

    [InverseProperty("Warehouse")]
    public virtual WarehouseConfiguration? WarehouseConfiguration { get; set; }
}
