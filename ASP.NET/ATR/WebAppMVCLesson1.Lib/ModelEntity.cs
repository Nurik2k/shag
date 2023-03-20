using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebAppMVCLesson1.Lib
{
    public partial class ModelEntity : DbContext
    {
        public ModelEntity()
            : base("name=ModelEntity")
        {
        }

        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomProperty> RoomProperty { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<SliderAreas> SliderAreas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .Property(e => e.Square)
                .HasPrecision(18, 0);

            modelBuilder.Entity<RoomType>()
                .HasMany(e => e.Room)
                .WithRequired(e => e.RoomType)
                .WillCascadeOnDelete(false);
        }
    }
}
