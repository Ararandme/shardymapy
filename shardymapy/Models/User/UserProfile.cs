using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models.User;

[Table("user_profile")]
[Index("UserId", Name = "UKebc21hy5j7scdvcjt0jy6xxrv", IsUnique = true)]
public partial class UserProfile
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("user_id")]
    public long? UserId { get; set; }

    [Column("apellidos")]
    [StringLength(255)]
    public string? Apellidos { get; set; }

    [Column("correos")]
    [StringLength(255)]
    public string? Correos { get; set; }

    [Column("nombre")]
    [StringLength(255)]
    public string? Nombre { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserProfile")]
    public virtual User? User { get; set; }
}
