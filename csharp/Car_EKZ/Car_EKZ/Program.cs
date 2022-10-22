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
                    Console.WriteLine("1. Машины");
                    Console.WriteLine("2. Компоненты");
                    Console.WriteLine("3. Aккаунт");
                    Console.WriteLine("4. Создать останову");
                    Console.WriteLine("5. Список машин");
                    Console.WriteLine("0. Выйти");
                    Console.Write("Выберете пункты меню: ");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:

                            CreateModel();
                            break;
                        case 2:
                            Console.Clear();
                            AddComponents();
                            break;
                        case 3:
                            Console.Clear();
                            Account();
                            break;
                        case 5:
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
                Console.WriteLine("Введите ID машины");
                car.CarID = Convert.ToInt32(Console.ReadLine());

                result = cs.CreateCar(car);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Машина создана!");
                Thread.Sleep(1000);
            }

            return result;

        }
        static ReturnResult AddComponents()
        {
            ComponentsService cts = new ComponentsService(Path);
            Component comp = new Component();
            ReturnResult result = new ReturnResult();
            try
            {
               
                    Console.WriteLine("Добавить компонент: ");
                    Console.WriteLine("1. Добавить компоненты");
                    Console.WriteLine("2. Показать все компоненты");
                    Console.WriteLine("0. Выход");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.Write("Введите название компонента: ");
                            comp.ComponentsName = Console.ReadLine();
                            result = cts.CreateComponents(comp);
                            Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Компонент создан!");
                            Thread.Sleep(1000);
                            break;
                        case 2:
                            Console.WriteLine(cts.PrintComponents(cts.GetComponents()));
                            break;
                    }


                    Thread.Sleep(1000);
                

               
            }
            catch (Exception) { }
            return result;
        }
        static ReturnResult Account()
        {
            User user = new User();
            UserService USV = new UserService(Path);
            ReturnResult result = new ReturnResult();
            Console.WriteLine("1. Создать Аккаунт");
            Console.WriteLine("2. Вывести Аккаунты");
            Console.WriteLine("0. Вернуться");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.Write("Введите Логин: ");
                    user.Login = Console.ReadLine();
                    Console.Write("Введите Пароль: ");
                    user.Password = Console.ReadLine();
                    Console.Write("Введите права на доступ: ");
                    user.AccessRights = Console.ReadLine();
                    result = USV.CreateUser(user);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Аккаунт создан!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine(USV.PrintUsers(USV.GetUsers()));
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                case 0:
                    Console.Clear();
                    break;
            }
            return result;
        }
        static ReturnResult ShutdownC()
        {
            Shutdown shutdown = new Shutdown();
            ShutdownService STD = new ShutdownService(Path);
            ReturnResult result = new ReturnResult();
            Console.WriteLine("1. Создать Останову");
            Console.WriteLine("2. Вывести все Остановы");
            Console.WriteLine("0. Вернуться");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    shutdown.DateCreat = DateTime.Now;
                    Console.WriteLine("Введите ");
                    break;
            }

        }
    }
    
}
