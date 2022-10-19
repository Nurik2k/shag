using Car_EKZ.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ
{
    internal class Program
    {
        static string Path = @"C:\Temp\MyData.db";
        public enum Model { BMW, Audi, Toyota};
        static void Main(string[] args)
        {
            Console1();
        }
        static void Console1()
        {
            int ch = 0;
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
                //switch (ch)
                //{
                //    case 1:
                //        CreateModel();
                //        break;
                //}
                if(ch == 1)
                {
                    CreateModel();
                }
            }
            catch (Exception) { throw; }
        }
        static void CreateModel()
        {
            int ch1 = 0;
            Console.WriteLine("Выберите модель машины");
            Console.WriteLine(Model.BMW.ToString() + " 1 " + Model.Audi.ToString() + " 2 " + Model.Toyota.ToString() + " 3 ");
            if(ch1 == 0)
            {
                Console.Clear();
                Console1();
            }
            else 
            {
                switch (ch1)
                {
                case 1:
                    Console.WriteLine("Машина модели: " + Model.BMW + "создана");
                    break;
                case 2:
                    Console.WriteLine("Машина модели: " + Model.Audi + "создана");
                    break;
                case 3:
                    Console.WriteLine("Машина модели: " + Model.Toyota + "создана");
                    break;
                }
            }
            
        }
    }
    
}
