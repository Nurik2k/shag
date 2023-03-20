using Microsoft.EntityFrameworkCore;


namespace WebAppMVCLesson1.Admin.Models
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<EventCategory> EventCategories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EventCategory>().HasData
        //        (
        //        new EventCategory()
        //        {
        //            EventCategoryId = 1,
        //            Name = "CategoryName",
        //            Description = "test"
        //        }
        //        );
        //}
    }
}
