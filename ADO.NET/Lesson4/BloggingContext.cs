using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_core
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=NURIK;Database=BlogDb;Trusted_Connection=true;Encrypt=false");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Blog>().HasData(new List<Blog>()
            {
                new Blog(){AuthorName="Nurik",
                    Content="i'm Mickelangelo.",
                    Id=1,
                    LikeCount=10_000_000,
                    Url="cartoonnetwork.com"},
                new Blog(){AuthorName="Katya",
                    Content="i'm Batman",
                    Id=2,
                    LikeCount=250_000,
                    Url="tiktok.com"},
            });
        }
    }
    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public string AuthorName { get; set; }
    }
}
