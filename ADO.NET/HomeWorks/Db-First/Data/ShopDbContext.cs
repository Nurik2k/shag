using System;
using System.Collections.Generic;
using Db_First.Models;
using Microsoft.EntityFrameworkCore;

namespace Db_First.Data;

public partial class ShopDbContext : DbContext
{
    public ShopDbContext()
    {
    }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<BasketProduct> BasketProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NURIK;Initial Catalog=ShopDb;Trusted_Connection=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>(entity =>
        {
            entity.ToTable("Basket");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Basket_User");
        });

        modelBuilder.Entity<BasketProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BasketUser");

            entity.ToTable("BasketProduct");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BasketId).HasColumnName("basket_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Basket).WithMany(p => p.BasketProducts)
                .HasForeignKey(d => d.BasketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BasketProduct_Basket");

            entity.HasOne(d => d.Product).WithMany(p => p.BasketProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BasketProduct_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(1000)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("card_number");
            entity.Property(e => e.Login)
                .HasMaxLength(500)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
