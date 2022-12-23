using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KIWI.dll
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AccoutService> AccoutServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
