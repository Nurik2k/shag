namespace WebAppMVCLesson1.Lib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomType")]
    public partial class RoomType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomType()
        {
            Room = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string RoomTypeDescription { get; set; }

        public int? Price { get; set; }

        [StringLength(1000)]
        public string Imagepath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Room { get; set; }
    }
}
