using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public class Console1
    {
        public Console1()
        {

        }
        private string Path { get; set; }
        CarService carService = new CarService();
        public Console1(string Path)
        {
            this.Path = Path;
        }
        public void ConsoleCar()
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
                    Console.WriteLine("0. Выйти");
                    Console.Write("Выберете пункты меню: ");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:

                            carService.CreateModel();
                            break;
                    }

                }
                catch (Exception) { throw; }
               
                if (ch == 0) 
                    break;
                    else { 
                    Thread.Sleep(1000);
                    Console.Clear();
                    ConsoleCar();
                
                    }

                

            } while (true);
           
        }
    }
}
