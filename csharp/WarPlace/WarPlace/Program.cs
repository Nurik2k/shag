using WarPlace.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarPlace
{
    public class Program
    {
        static void Main(string[] args)
        {
            string WinT34 = null;
            string WinPantera = null;

            TankT34[] t34 = new TankT34[5];
            TankPantera[] pantera = new TankPantera[5];

            for (int i = 1; i < 5; i++)
            {
                Tank.Ataka(t34[i], pantera[i]);

                if (TankT34.TotalPoint > TankPantera.TotalPoint)
            {
                WinT34 = string.Format("Танк T34 под номером {0} победил!", t34[i]);
                Console.WriteLine(WinT34);
            }
            else
            {
                WinPantera = string.Format("Танк Pantera под номером {0} победил!", pantera[i]);
                Console.WriteLine(WinPantera);
            }
            }
            

           
        }
    }
}
