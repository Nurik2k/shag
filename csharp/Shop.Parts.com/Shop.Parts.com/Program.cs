
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Parts.com
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int MenuChoice = 0;
            SalesMan salesMan = new SalesMan();
            Console.WriteLine("Войти <1>");
            Console.WriteLine("Список товара на складе (Астана, Аламты, Караганда)  <2>");
            Console.WriteLine("Аукционный товар <3>");
            Console.Write("Выберете пункты меню: ");
            MenuChoice = Convert.ToInt32(Console.ReadLine());
            switch (MenuChoice)
            {
                case 1:
                    {
                        string Login;
                        string Password;
                        Console.Clear();
                        Console.Write("Введите логин: ");
                        Login = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        Password = Console.ReadLine();
                        
                    }

            }
        }
    }
}
