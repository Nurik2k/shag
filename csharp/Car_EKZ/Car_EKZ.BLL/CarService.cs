using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
     public class CarService
    {

        public void CreateModel()
        {
            string Model;
            Console.WriteLine("1. Создать модель");
            Console.WriteLine("0. Назад");
            int ch1 = Convert.ToInt32(Console.ReadLine());
            if (ch1 == 0)
            {
                Console.Clear();
                Console1 console1 = new Console1();
                console1.ConsoleCar();
            }
            else
            {
                Console.WriteLine("Введите модель машины");
                Model = Console.ReadLine();
                Console.WriteLine("Машина модели: " + Model + " создана");
            }

        }
    }
}
