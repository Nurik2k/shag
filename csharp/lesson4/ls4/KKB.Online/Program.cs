using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.Online
{
    class Program
    {
        static void Main(string[] args)
        {
           

        UserService userService = new UserService();

            string message = "";

            User user = new User();

            user.Accounts = null;

            user, Address = null;

            user.Birth = new DateTime(1988, 01, 11); user IIN = "880111300392";

            user.Name = "Yevgeniy";

            user.SecondName = "Gertsen"; user.Password = "123";

            user.PhoneNumber = "+7 777 209 43 43"; aser Sex = "M":

            if (userService.Registration(user, out message)) 
                Console.WriteLine(message);

            else

                Console.WriteLine(message);

        }
    }
}
