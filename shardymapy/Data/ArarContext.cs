using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using shardymapy.Models;

namespace shardymapy.Data;

public partial class ArarContext : DbContext
{
    public ArarContext()
    {
    }

    public ArarContext(DbContextOptions<ArarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anaquel> Anaquels { get; set; }

    public virtual DbSet<AnaquelAnaquelLineaCelda> AnaquelAnaquelLineaCeldas { get; set; }

    public virtual DbSet<AnaquelLineaCelda> AnaquelLineaCeldas { get; set; }

    public virtual DbSet<AnaquelLineaCeldasSubdivision> AnaquelLineaCeldasSubdivisions { get; set; }

    public virtual DbSet<AnaquelLineaVistaFrontalConfiguration> AnaquelLineaVistaFrontalConfigurations { get; set; }

    public virtual DbSet<AnaquelLineaVistaSuperiorConfiguracion> AnaquelLineaVistaSuperiorConfiguracions { get; set; }

    public virtual DbSet<AnaquelSubdivision> AnaquelSubdivisions { get; set; }

    public virtual DbSet<Nave> Naves { get; set; }

    public virtual DbSet<NaveAnaquele> NaveAnaqueles { get; set; }

    public virtual DbSet<NaveConfiguration> NaveConfigurations { get; set; }

    public virtual DbSet<Sku> Skus { get; set; }

    public virtual DbSet<SkuDataLogistica> SkuDataLogisticas { get; set; }

    public virtual DbSet<SkuKardex> SkuKardices { get; set; }

    public virtual DbSet<SkuSkuKardex> SkuSkuKardexs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseConfiguration> WarehouseConfigurations { get; set; }

    public virtual DbSet<WarehouseNafe> WarehouseNaves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=arar;user=root;password=NewStrongPass!23;sslmode=None", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Anaquel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Nave).WithMany(p => p.Anaquels).HasConstraintName("FKc3qdvxqm7wty5v4wnlwb51r3t");
        });

        modelBuilder.Entity<AnaquelAnaquelLineaCelda>(entity =>
        {
            entity.HasOne(d => d.Anaquel).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK204n6qexj59jxhqwnut8he4y7");

            entity.HasOne(d => d.AnaquelLineaCeldas).WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKhaft0r5nkooyjf4f20tmbmy9t");
        });

        modelBuilder.Entity<AnaquelLineaCelda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Anaquel).WithMany(p => p.AnaquelLineaCelda).HasConstraintName("FK2qeq8vffs4ri8u0xqgeqjia9a");
        });

        modelBuilder.Entity<AnaquelLineaCeldasSubdivision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Anaquel).WithMany(p => p.AnaquelLineaCeldasSubdivisions).HasConstraintName("FKfonl2cesdf3eedhnv2623g3vn");

            entity.HasOne(d => d.AnaquelSubdivion).WithOne(p => p.AnaquelLineaCeldasSubdivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK6hdl24ei4f4cc5cgfrtc5kcny");
        });

        modelBuilder.Entity<AnaquelLineaVistaFrontalConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.AnaquelFrontalconfig).WithOne(p => p.AnaquelLineaVistaFrontalConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKjjw9sy5onhnu3qdt5jj9s05t4");
        });

        modelBuilder.Entity<AnaquelLineaVistaSuperiorConfiguracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.AnaquelSupconfig).WithOne(p => p.AnaquelLineaVistaSuperiorConfiguracion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKqnuvg912lrfhj0fuer33du719");
        });

        modelBuilder.Entity<AnaquelSubdivision>(entity =>
        {
            entity.HasOne(d => d.Anaquel).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKena8ecuwi1fm569wth6pw4fbc");

            entity.HasOne(d => d.Subdivisions).WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK8l9r57suc1niqikk0fooyaua8");
        });

        modelBuilder.Entity<Nave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Naves)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKisya2y7ihhv5cv82icglsfqry");
        });

        modelBuilder.Entity<NaveAnaquele>(entity =>
        {
            entity.HasOne(d => d.Anaqueles).WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK52x108vkx9ab95hwy830ylfso");

            entity.HasOne(d => d.Nave).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1lelktpo3yrw3i43cf0sqp5ur");
        });

        modelBuilder.Entity<NaveConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Nave).WithOne(p => p.NaveConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKunv9eb457urlg8mg7jkpmfx0");
        });

        modelBuilder.Entity<Sku>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<SkuDataLogistica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Sku).WithOne(p => p.SkuDataLogistica).HasConstraintName("FKeqc89ccpl019g24li5co1dnn3");
        });

        modelBuilder.Entity<SkuKardex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Sku).WithMany(p => p.SkuKardices).HasConstraintName("FKtdtgex1c1dh4hsaw98yy7i1jp");
        });

        modelBuilder.Entity<SkuSkuKardex>(entity =>
        {
            entity.HasOne(d => d.Sku).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKm5u6yd69j40pm6if7dqfobwnr");

            entity.HasOne(d => d.SkuKardexs).WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKbie0wnwaqj05kk9qx2imkm58i");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.User).WithOne(p => p.UserProfile).HasConstraintName("FK6kwj5lk78pnhwor4pgosvb51r");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<WarehouseConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Warehouse).WithOne(p => p.WarehouseConfiguration)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKmmg6drke4faicsma55w9pvj86");
        });

        modelBuilder.Entity<WarehouseNafe>(entity =>
        {
            entity.HasOne(d => d.Naves).WithOne()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKk0tgdppewjhpuqti1sk0c6l44");

            entity.HasOne(d => d.Warehouse).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKdysdyab4xwdcxngio58wwmxo5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
