using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Keyless]
[Table("sku_sku_kardexs")]
[Index("SkuId", Name = "FKm5u6yd69j40pm6if7dqfobwnr")]
[Index("SkuKardexsId", Name = "UKa1v1x814jensi2bc7srejx8sv", IsUnique = true)]
public partial class SkuSkuKardex
{
    [Column("sku_kardexs_id")]
    public int SkuKardexsId { get; set; }

    [Column("sku_id")]
    public long SkuId { get; set; }

    [ForeignKey("SkuId")]
    public virtual Sku Sku { get; set; } = null!;

    [ForeignKey("SkuKardexsId")]
    public virtual SkuKardex SkuKardexs { get; set; } = null!;
}
