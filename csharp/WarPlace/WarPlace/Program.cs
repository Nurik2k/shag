using WarPlace.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarPlace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TankT34 t34 = null;
            
                for (int i = 1; i <= 5; i++)
                {
                    Console.Write("Имя танка T34 {0}: ", i);
                    t34.NameT34 = Console.ReadLine();
                    t34.tankT34s.Add(t34);
                }
                 Console.WriteLine(t34.NameT34);
        }
    }
}
