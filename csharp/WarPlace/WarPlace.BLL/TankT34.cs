using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarPlace.BLL
{
    public class TankT34
    {
        string NameT34 { get; set; }
        public void T34(int Hp, int Ammo, int Maneuverability)
        {
            Random rnd = new Random();
            Hp = rnd.Next(0, 100);
            Ammo = rnd.Next(0, 100);
            Maneuverability = rnd.Next(0, 100);
        }
        
    }
}
