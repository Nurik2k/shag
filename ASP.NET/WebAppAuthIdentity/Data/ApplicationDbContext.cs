//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using WebAppAuthIdentity.Models;

//namespace WebAppAuthIdentity.Data;

//public partial class ApplicationDbContext : DbContext
//{
//    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<User> Users { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
