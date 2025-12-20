using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace shardymapy.Models;

[Table("user")]
public partial class User
{
    [Column("fecha_ingreso")]
    public DateOnly? FechaIngreso { get; set; }

    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("password")]
    [StringLength(255)]
    public string? Password { get; set; }

    [Column("username")]
    [StringLength(255)]
    public string? Username { get; set; }

    [InverseProperty("User")]
    public virtual UserProfile? UserProfile { get; set; }
}
