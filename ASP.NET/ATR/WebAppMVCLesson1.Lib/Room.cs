namespace WebAppMVCLesson1.Lib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        public int RoomId { get; set; }

        public int RoomTypeId { get; set; }

        public decimal? Square { get; set; }

        public int? MaxPersons { get; set; }

        public bool IsFreeWifi { get; set; }

        public bool IsPrivateBalcony { get; set; }

        public bool IsFullAC { get; set; }

        public int Floor { get; set; }

        public bool HasTV { get; set; }

        public bool IsBeachView { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
