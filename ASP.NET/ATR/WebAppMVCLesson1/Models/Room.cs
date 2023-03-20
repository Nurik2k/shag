using System;
using System.Collections.Generic;

namespace WebAppMVCLesson1.Models
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string Description { get; set; } = null!;
        public float Price { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; } = null!;
        public bool IsAvalible { get; set; }
        public int RoomNumber { get; set; }
        public int CategoryId { get; set; }
        public string MainPicturePath { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
    }
}
