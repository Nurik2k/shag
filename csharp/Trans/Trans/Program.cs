using Trans.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trans
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            CarsRandom carsRandom = new CarsRandom();
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var cr = new Car(rnd.Next());
                    cr.CarType = "Car type #" + i;
                    cr.Weight = rnd.Next(500, 2500);
                    cr.Brand = "Brand type #" + i;
                    cr.Speed = rnd.Next(0, 5000);
                    carsRandom.AddTrans(cr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                var mc = new Moto(rnd.Next(0, 2500), rnd.Next(0, 500));
                mc.CarType = "Motocycle type #" + i;
                mc.Weight = 150;
                mc.MotoNumber = "MC" + rnd.Next(1, 895623);
                mc.MotoType = "MotoType #" + i;

            }
            carsRandom.PrintInfo();
        }
    }
}
