
using Microsoft.EntityFrameworkCore;
using shardymapy.Models.Anaquel;
using shardymapy.Models.Items;
using shardymapy.Models.Naves;
using shardymapy.Models.User;
using shardymapy.Models.Warehouse;

namespace shardymapy.Data;

public partial class MapyContext : DbContext
{
    public MapyContext()
    {
    }

    public MapyContext(DbContextOptions<MapyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anaquel> Anaquels { get; set; }


    public virtual DbSet<AnaquelLineaCelda> AnaquelLineaCeldas { get; set; }

    public virtual DbSet<AnaquelLineaCeldasSubdivision> AnaquelLineaCeldasSubdivisions { get; set; }

    public virtual DbSet<AnaquelLineaVistaFrontalConfiguration> AnaquelLineaVistaFrontalConfigurations { get; set; }

    public virtual DbSet<AnaquelLineaVistaSuperiorConfiguracion> AnaquelLineaVistaSuperiorConfiguracions { get; set; }
    
    public virtual DbSet<Nave> Naves { get; set; }
    
    public virtual DbSet<NaveConfiguration> NaveConfigurations { get; set; }

    public virtual DbSet<Sku> Skus { get; set; }

    public virtual DbSet<SkuDataLogistica> SkuDataLogisticas { get; set; }

    public virtual DbSet<SkuKardex> SkuKardices { get; set; }
    
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseConfiguration> WarehouseConfigurations { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Anaquel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

        });
        

        modelBuilder.Entity<AnaquelLineaCelda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Anaquel).WithMany(p => p.AnaquelLineaCelda).HasConstraintName("FK2qeq8vffs4ri8u0xqgeqjia9a");
        });

        modelBuilder.Entity<AnaquelLineaCeldasSubdivision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            
            entity.HasOne(d => d.AnaquelSubdivion).WithOne(p => p.AnaquelLineaCeldasSubdivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK6hdl24ei4f4cc5cgfrtc5kcny");
        });

        modelBuilder.Entity<AnaquelLineaVistaFrontalConfiguration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

           
        });

        modelBuilder.Entity<AnaquelLineaVistaSuperiorConfiguracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            
        });
        

        modelBuilder.Entity<Nave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.Naves)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKisya2y7ihhv5cv82icglsfqry");
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

        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
