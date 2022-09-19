using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarPlace.BLL
{
    internal class TankPantera
    {
        string NamePantera { get; set; }
        public void Pantera(int Hp, int Ammo, int Maneuverability)
        {
            Random rnd = new Random();
            Hp = rnd.Next(0, 100);
            Ammo = rnd.Next(0, 100);
            Maneuverability = rnd.Next(0, 100);
        }
    }
}
