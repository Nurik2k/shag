using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace KKB.Online.Lib
{
    public class Notifiation
    {

        public void ResultCreateAccount(string message, bool result, string accountIBAN)
        {
            if (result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Поздравляем Ваш счет {0} {1}", accountIBAN, message);
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;

            }

        }
        public static void WriteExeption(Exception ex, int userid)
        {
            //запишем ошибку в файл
        }
    }
}
