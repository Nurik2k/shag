using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ATR.WebApi.Models;

namespace ATR.WebApi.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Carusel> Carusels { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<JobPosition> JobPositions { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<PageStatistic> PageStatistics { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomProperty> RoomProperties { get; set; } = null!;
        public virtual DbSet<TeamWork> TeamWorks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
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

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
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

            modelBuilder.Entity<JobPosition>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Ip)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Level).HasMaxLength(128);

                entity.Property(e => e.Properties).HasColumnType("xml");

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<PageStatistic>(entity =>
            {
                entity.ToTable("PageStatistic");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Path).HasMaxLength(500);

                entity.Property(e => e.PathBase).HasMaxLength(500);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Rooms_CategoryId");

                //entity.HasOne(d => d.Category)
                //    .WithMany(p => p.Rooms)
                //    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<RoomProperty>(entity =>
            {
                entity.HasMany(d => d.RoomsRooms)
                    .WithMany(p => p.RoomPropertiesRoomProperties)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoomRoomProperty",
                        l => l.HasOne<Room>().WithMany().HasForeignKey("RoomsRoomId"),
                        r => r.HasOne<RoomProperty>().WithMany().HasForeignKey("RoomPropertiesRoomPropertyId"),
                        j =>
                        {
                            j.HasKey("RoomPropertiesRoomPropertyId", "RoomsRoomId");

                            j.ToTable("RoomRoomProperty");

                            j.HasIndex(new[] { "RoomsRoomId" }, "IX_RoomRoomProperty_RoomsRoomId");
                        });
            });

            modelBuilder.Entity<TeamWork>(entity =>
            {
                entity.HasIndex(e => e.JobPositionId, "IX_TeamWorks_JobPositionId");

                entity.Property(e => e.AboutWork).HasMaxLength(1024);

                entity.Property(e => e.Autor).HasMaxLength(250);

                entity.Property(e => e.FaceBook).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.Instagram).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.LinkedIn).HasMaxLength(250);

                entity.Property(e => e.MiddleName).HasMaxLength(250);

                entity.Property(e => e.Photo).HasMaxLength(250);

                entity.HasOne(d => d.JobPosition)
                    .WithMany(p => p.TeamWorks)
                    .HasForeignKey(d => d.JobPositionId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(250)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
