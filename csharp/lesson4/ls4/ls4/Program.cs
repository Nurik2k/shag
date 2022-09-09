using KKB.Online;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.Online
{
    internal class Program
    {
        static string Path = @"C:\Temp\MyData.db";
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            UserService userService = new UserService(Path);

            string message = "";

            User user = new User();
            user.Accounts = null;
            user.Address = null;
            user.Birth = new DateTime(1988, 01, 11);
            user.IIN = "880111300392";
            user.Name = "Yevgeniy";
            user.SecondName = "Gertsen";
            user.Password = "123";
            user.PhoneNumber = "+7 777 209 43 43";
            user.Sex = "M";

            if (userService.Registration(user, out message))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
