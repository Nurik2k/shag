using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Game.DLL
{
    public class GameContext : DbContext
    {
        public DbSet<Model> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=NURIK;Database=GameDb;Trusted_Connection=true;Encrypt=false");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Model>().HasData(new List<Model>()
            {
                new Model()
                {
                   Id= 1,
                   GameName = "God of war",
                   GameDeveloper = "Santa Monica Studio",
                   GameStyle = "Action",
                   GameMode = "God killer",
                   Sells = 10000000,
                   PublishYear = 2018
                }
            });
        }
    }
}

