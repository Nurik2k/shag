namespace WebAppMVCLesson1.Lib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomProperty")]
    public partial class RoomProperty
    {
        public int RoomPropertyId { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
