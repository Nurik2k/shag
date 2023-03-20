namespace WebAppMVCLesson1.Lib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Service")]
    public partial class Service
    {
        public int ServiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; }

        [Required]
        [StringLength(500)]
        public string ServiceDescription { get; set; }

        [Required]
        [StringLength(500)]
        public string ServiceIconPath { get; set; }

        [Required]
        [StringLength(500)]
        public string ServiceImagePath { get; set; }
    }
}
