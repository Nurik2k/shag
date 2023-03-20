using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppMVCLesson1.NewAdmin.Modals;

namespace WebAppMVCLesson1.NewAdmin.DataContext;

public partial class WebAppMVCLesson1DbContext : DbContext
{
    public WebAppMVCLesson1DbContext()
    {
    }

    public WebAppMVCLesson1DbContext(DbContextOptions<WebAppMVCLesson1DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Carusel> Carusels { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<RoomProperty> RoomProperties { get; set; }
    public virtual DbSet<TeamWork> TeamWorks { get; set; }
    public virtual DbSet<JobPosition> JobPositions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=NURIK;Database=ATR;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.HasDefaultSchema("Admin");

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Carusel>(entity =>
        {
            entity.ToTable("Carusel");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUser).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(2500);
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.PictureUrl).HasMaxLength(500);
            entity.Property(e => e.Tirle).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);

        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebAppMVCLesson1DbContext).Assembly);
    }

    public class CaruselEntityConfig: IEntityTypeConfiguration<Carusel>
    {
        public void Configure(EntityTypeBuilder<Carusel> modelBuilder)
        {

            modelBuilder.ToTable("Carusel");

            modelBuilder.Property(e => e.CreateDate).HasColumnType("datetime");
            modelBuilder.Property(e => e.CreateUser).HasMaxLength(500);
            modelBuilder.Property(e => e.Description).HasMaxLength(2500);
            modelBuilder.Property(e => e.ExpireDate).HasColumnType("datetime");
            modelBuilder.Property(e => e.PictureUrl).HasMaxLength(500);
            modelBuilder.Property(e => e.Tirle).HasMaxLength(500);
            
        }
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
