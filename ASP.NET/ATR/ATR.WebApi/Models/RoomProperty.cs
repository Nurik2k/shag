using System;
using System.Collections.Generic;

namespace ATR.WebApi.Models
{
    public partial class RoomProperty
    {
        public RoomProperty()
        {
            RoomsRooms = new HashSet<Room>();
        }

        public int RoomPropertyId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Room> RoomsRooms { get; set; }
    }
}
