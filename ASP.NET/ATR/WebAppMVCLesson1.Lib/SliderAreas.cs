namespace WebAppMVCLesson1.Lib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SliderAreas
    {
        [Key]
        public int SliderAreaId { get; set; }

        [StringLength(100)]
        public string Header { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(500)]
        public string Url { get; set; }

        [StringLength(500)]
        public string PathImg { get; set; }
    }
}
