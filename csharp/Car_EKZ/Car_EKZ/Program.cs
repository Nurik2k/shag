using Car_EKZ.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Car_EKZ
{
    public class Program
    {
        
        static string Path = @"C:\Temp\MyData.db";
        static void Main(string[] args)
        {
            ConsoleCar();
        }



        static void ConsoleCar()
        {
            int ch = -1;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    User user = new User(Path);



                    Console.WriteLine("Добро пожаловать в СТО");
                    Console.WriteLine("");
                    Console.WriteLine("1. Создать машину");
                    Console.WriteLine("2. Создать компонент");
                    Console.WriteLine("3. Создать проект");
                    Console.WriteLine("4. Создать аккаунт");
                    Console.WriteLine("5. Создать останову");
                    Console.WriteLine("6. Список машин");
                    Console.WriteLine("0. Выйти");
                    Console.Write("Выберете пункты меню: ");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:

                            CreateModel();
                            break;
                        case 2:
                            Components components = new Components();
                            AddComponents();
                            break;
                        case 6:
                            CarService carService = new CarService(Path);

                            Console.WriteLine(carService.PrintCar(carService.GetCars()));
                            break;
                    }

                }
                catch (Exception) { throw; }

                if (ch == 0)
                    break;
                else
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    ConsoleCar();

                }



            } while (true);

        }




        static ReturnResult CreateModel()
        {
            CarService cs = new CarService(Path);
            ReturnResult result = new ReturnResult();

            Car car = new Car();
            Console.WriteLine("1. Создать машину");
            Console.WriteLine("0. Назад");
            int ch1 = Convert.ToInt32(Console.ReadLine());
            if (ch1 == 0)
            {
                Console.Clear();
                ConsoleCar();
            }
            else
            {
                Console.WriteLine("Введите модель машины");
                car.CarModel = Console.ReadLine();
                Console.WriteLine("Введите имя машины");
                car.CarName = Console.ReadLine();
                Console.WriteLine("Введите тип машины");
                car.Type = Console.ReadLine();
                Console.WriteLine("Введите гаражный номер машины");
                car.GarageNumber = Convert.ToInt32(Console.ReadLine());

                result = cs.CreateCar(car);
                Console.Clear();
                
                Console.WriteLine("Машина создана!");
                Thread.Sleep(1000);
            }

            return result;

        }
        static void AddComponents()
        {
            Components components = new Components(Path);
            List<Components> componentsArr = new List<Components>();
            try
            {

                string cmpnts = null;
                int ch = 0;
                do
                {
                    Console.WriteLine("Добавить компонент: ");
                    Console.WriteLine("1. Добавить компоненты");
                    Console.WriteLine("2. Выход");
                    Console.WriteLine("3. Показать все компоненты");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Введите название компонента: ");
                            cmpnts = Convert.ToString(Console.ReadLine());
                            componentsArr.Add(components);
                            Console.Clear();
                            Console.WriteLine();
                            break;
                        case 3:
                            components.GetComponents();
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                    }


                    Thread.Sleep(1000);
                }

                while (ch != 2);
            }
            catch (Exception) { }
        }

    }
    
}
