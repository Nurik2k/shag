using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarPlace.BLL
{
    public abstract class Tank
    {
        static Random random = new Random();
        int Ammo = random.Next(0, 100);
        int Hp = random.Next(0, 100);
        int Maneuverability = random.Next(0, 100);

        // В данной логике не учитывается что параметры могут быть одинаковые
        public static void Ataka(TankT34 t34, TankPantera pantera)
        {
            int pointT34 = 0, pointPantera = 0;

            if (t34.Ammo > pantera.Ammo) pointT34++;
            else pointPantera++;

            if (t34.Hp > pantera.Hp) pointT34++;
            else pointPantera++;

            if (t34.Maneuverability > pantera.Maneuverability) pointT34++;
            else pointPantera++;

            
            
                
                
            
        }
    }

  
}
