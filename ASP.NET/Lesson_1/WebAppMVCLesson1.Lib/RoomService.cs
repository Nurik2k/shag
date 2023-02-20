using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVCLesson1.Lib
{
    public class RoomService
    {
        ModelEntity db = new ModelEntity();
        public bool AddRoomProperies(RoomProperty roomProp)
        {
            try
            {
                db.RoomProperty.Add(roomProp);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
