using System;
using System.Collections.Generic;
using Finaldb.Models;
using Microsoft.EntityFrameworkCore;

namespace Finaldb.Data;

public partial class ChatDbContext : DbContext
{
    public ChatDbContext()
    {
    }

    public ChatDbContext(DbContextOptions<ChatDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupMessage> GroupMessages { get; set; }

    public virtual DbSet<PrivateMessage> PrivateMessages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NURIK;Initial Catalog=ChatDb;Trusted_Connection=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Group");

            entity.HasIndex(e => e.OwnerId, "IX_Groups_OwnerId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.Groups)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Groups__owner_id__3D5E1FD2");
        });

        modelBuilder.Entity<GroupMessage>(entity =>
        {
            entity.HasIndex(e => e.GroupId, "IX_GroupMessages_GroupId");

            entity.HasIndex(e => e.UserId, "IX_GroupMessages_UserId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupMessages)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_GroupMessages_Groups");

            entity.HasOne(d => d.User).WithMany(p => p.GroupMessages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_GroupMessages_Users");
        });

        modelBuilder.Entity<PrivateMessage>(entity =>
        {
            entity.HasIndex(e => e.CreateDate, "IX_PrivateMessages_CreateDate");

            entity.HasIndex(e => e.CreateDate, "IX_PrivateMessages_CreateDate_DESC").IsDescending();

            entity.HasIndex(e => e.FromUserId, "IX_PrivateMessages_FromUserId");

            entity.HasIndex(e => e.ToUserId, "IX_PrivateMessages_ToUserId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalInfo).HasColumnName("additional_info");
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.FromUserId).HasColumnName("from_user_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsUserInBlackList).HasColumnName("is_user_in_black_list");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.ToUserId).HasColumnName("to_user_id");

            entity.HasOne(d => d.FromUser).WithMany(p => p.PrivateMessageFromUsers)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrivateMessages_Users_From_User_Id");

            entity.HasOne(d => d.ToUser).WithMany(p => p.PrivateMessageToUsers)
                .HasForeignKey(d => d.ToUserId)
                .HasConstraintName("FK_PrivateMessages_Users_To_User_Id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Login, "login_UQ").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(500)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .HasColumnName("password");
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.HasIndex(e => e.GroupId, "IX_UserGroupd_GroupId");

            entity.HasIndex(e => e.UserId, "IX_UserGroups_UserId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.UserGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserGroups_Group");

            entity.HasOne(d => d.User).WithMany(p => p.UserGroups)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserGroups_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
