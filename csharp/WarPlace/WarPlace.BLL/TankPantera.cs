using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarPlace.BLL
{
    public class TankPantera : Tank
    {
        public string NamePantera { get; set; }
        public static int TotalPoint { get; private set; }

        public static void AddTotalPoint()
        {
            TotalPoint++;
        }
    }
}
