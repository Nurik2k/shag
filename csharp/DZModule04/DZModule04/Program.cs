using DZModule04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case_1
{

    class Program : Car
    {
        static void Main(string[] args)
        {
            Car Car1 = new Car();
            Car Car2 = new Car("reno");
            Car[] car3Cars = new Car[5];
            for (int i = 0; i < car3Cars.Length; i++)
            {
                car3Cars[i] = new Car();
            }
            
            //Car2.Print();
            Console.WriteLine();
            Car1.maxSpeed = 9;
            Console.WriteLine(Car1.maxSpeed);
            Car1.Print(ref Car1);
            Console.WriteLine();
            Car1.Print();
            Console.WriteLine();
            Console.WriteLine(Car.carForeign);
        }
    }
}