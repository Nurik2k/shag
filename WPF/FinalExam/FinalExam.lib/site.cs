namespace FinalExam.lib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class site
    {
        public int id { get; set; }

        [Required]
        [StringLength(150)]
        public string url { get; set; }

        public bool url_status { get; set; }
    }
}
