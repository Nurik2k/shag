using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<PersonAddress> PeopleAddresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=Nurik;Database=PeopleDb;Trusted_Connection=true;Encrypt=false");
        }
    }
}
