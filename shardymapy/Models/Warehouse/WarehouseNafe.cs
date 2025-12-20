using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Keyless]
[Table("warehouse_naves")]
[Index("WarehouseId", Name = "FKdysdyab4xwdcxngio58wwmxo5")]
[Index("NavesId", Name = "UK2bvl9v9cfhehl1ck4hmldqdda", IsUnique = true)]
public partial class WarehouseNafe
{
    [Column("naves_id")]
    public long NavesId { get; set; }

    [Column("warehouse_id")]
    public long WarehouseId { get; set; }

    [ForeignKey("NavesId")]
    public virtual Nave Naves { get; set; } = null!;

    [ForeignKey("WarehouseId")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
