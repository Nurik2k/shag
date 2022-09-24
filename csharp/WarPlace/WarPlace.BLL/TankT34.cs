using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WarPlace.BLL
{
    public class TankT34 : Tank
    {
        public string NameT34 { get; set; }
        public static int TotalPoint { get; private set; }

        public static void AddTotalPoint()
        {
            TotalPoint++;
        }

    }
}