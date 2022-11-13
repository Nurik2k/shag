using Azure.Core;
using Finaldb.Data;
using Finaldb.Models;
using System.Collections;
using System.Security.Cryptography;



namespace FinalDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var DbContext = new ChatDbContext();
            try
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Регистрация");
                int ch = Int32.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Registration(DbContext);
                        break;
                    case 2:
                        HashPass();
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Registration(ChatDbContext db)
        {
            User newUser = new User();
            Console.Write("Введите логин: ");
            newUser.Login = Console.ReadLine();
            
            db.Users.Add(newUser);
            db.SaveChanges();
            Console.WriteLine("Успешно добавлено!");
        }
        static void HashPass()
        {
            User newUser = new User();
            Console.Write("Введите пароль: ");
            newUser.Password = Console.ReadLine();
            Hashtable hashtable= new Hashtable();
            hashtable.Add(newUser.Password, newUser);
            Console.WriteLine(hashtable);
        }
       
    }
}

