using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
    public class StockContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=NURIK;Database=Stock;Trusted_Connection=true;Encrypt=false");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Stock>().HasData(new List<Stock>()
            {
                new Stock{ Id = 1,
                Product = "Iphone",
                Type= "Tech",
                Provider = "Nurik"},

                new Stock{ Id = 2,
                Product = "Apple",
                Type= "Fruit",
                Provider = "Katya"}
            }) ;
        }
    }
    public class Stock
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
    }
}

