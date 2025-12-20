using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Keyless]
[Table("anaquel_anaquel_linea_celdas")]
[Index("AnaquelId", Name = "FK204n6qexj59jxhqwnut8he4y7")]
[Index("AnaquelLineaCeldasId", Name = "UKs9v728au912iujulxmy3pem7d", IsUnique = true)]
public partial class AnaquelAnaquelLineaCelda
{
    [Column("anaquel_id")]
    public int AnaquelId { get; set; }

    [Column("anaquel_linea_celdas_id")]
    public int AnaquelLineaCeldasId { get; set; }

    [ForeignKey("AnaquelId")]
    public virtual Anaquel Anaquel { get; set; } = null!;

    [ForeignKey("AnaquelLineaCeldasId")]
    public virtual AnaquelLineaCelda AnaquelLineaCeldas { get; set; } = null!;
}
