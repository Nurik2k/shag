using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarPlace.BLL;

namespace WarPlace
{

   

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Tank[] VIN = new Tank[5];
            Tank[] T34 = new Tank[5];
            for (int i = 0; i < T34.Length; i++)
            {
                VIN[i] = new Tank();
            }
            for (int i = 0; i < T34.Length; i++)
            {
                T34[i] = new Tank(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100), "T34");
            }
            Tank[] pantera = new Tank[5];
            for (int i = 0; i < T34.Length; i++)
            {
                pantera[i] = new Tank(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100), "Pantera");
            }
            for (int i = 0; i < 5; i++)
            {
                T34[i].Print();
                pantera[i].Print(); ;
                VIN[i] = T34[i] * pantera[i];
                Console.WriteLine();
                Console.WriteLine($"В {i + 1} схватке победил");
                VIN[i].Print();
                Console.WriteLine();
                Console.WriteLine();
            }




        }
    }
}