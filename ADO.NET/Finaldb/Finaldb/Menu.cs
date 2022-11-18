using Finaldb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finaldb
{
    public class Menu
    {
        public void MainMenu()
        {
            UserService userService = new UserService();
            using var DbContext = new ChatDbContext();
            try
            {
                bool isDebug = true;

                Console.WriteLine("Select menu item:");
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Sign in");
                int ch = Int32.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        userService.Registration(DbContext);
                        break;
                    case 2:
                        string login = "", password = "";
                        Console.Write("Enter login: ");
                        //if (!isDebug)
                        //{
                        login = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password = Console.ReadLine();
                        //}
                        //else
                        //{
                        //    login = "Assir";
                        //    password = "321";
                        //}

                        userService.SignIn(login, password);
                        break;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void UserMenu(bool signIn)
        {
            if (signIn == true)
            {
                Console.WriteLine("1. Send message to user");
                Console.WriteLine("2. Send message to group");
                Console.WriteLine("3. Add group");
                Console.WriteLine("4. Block user");
                Console.WriteLine("0. Log out");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 0:

                        break;
                }
            }
        }
        public void SendMessage(ChatDbContext db)
        {

        }
    }
}
