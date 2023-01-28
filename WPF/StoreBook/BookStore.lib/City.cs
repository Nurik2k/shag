using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.lib
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
