using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace KIWI.dll
{
    [Table("AccoutService")]

    public partial class Operator
    {
            [Key]
            public int Id { get; set; }

            [Required]
            public string Phone { get; set; }

            [Required]
            public string Logo { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public float Percent { get; set; }
            [Required]
            public DateTime CreateDate { get; set; }
    }

}

