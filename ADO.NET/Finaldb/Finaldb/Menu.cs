using Finaldb.Data;
using Finaldb.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finaldb
{
    public class Menu
    {
        ConnectServer connect = new ConnectServer();
     
        public List<int> idmsg= new List<int>();
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
        public void UserMenu(User user)
        {
            UserService users = new UserService();
            using var DbContext = new ChatDbContext();
            if (user != null)
            {
                Console.WriteLine("1. Send message to user");
                Console.WriteLine("2. Send message to group");
                Console.WriteLine("3. Show messages");
                Console.WriteLine("4. Add group");
                Console.WriteLine("5. Block user");
                Console.WriteLine("0. Log out");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        GetActiveUsers();
                        Console.Write("Enter id: ");

                        int tou = int.Parse(Console.ReadLine());
                        SendMessage(user, tou, DbContext);
                        break;
                    case 2:

                        break;
                    case 3:
                        GetActiveUsers();
                        Console.Write("Enter id: ");
                        user.Id = int.Parse(Console.ReadLine());
                        ShowMessage(user.Id);
                        break;
                    case 0:

                        break;
                }
            }
        }
        public void SendMessage(User fromu,int tou, ChatDbContext db)
        {
            Console.Clear();
            
            try
            {
                while (true)
                {
                    PrivateMessage msg = new PrivateMessage();
                    Console.Write("!: ");
                    string message = Console.ReadLine();
                    msg.FromUserId = fromu.Id;
                    msg.ToUserId = tou;
                    msg.Message = message;
                    db.Add(msg);
                    db.SaveChanges();
                    Console.WriteLine($"{fromu.Login}:{msg.Message} [{msg.CreateDate}]");
                   
                }
                

                
            }
            catch(Exception ex) { Console.WriteLine(ex); }
            
        }
        public void ShowMessage(int id)
        {
            const string SqlQuery = "SELECT * FROM dbo.PrivateMessages WHERE to_user_id = @id or from_user_id = @id";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                var idMsg = reader.GetInt32(0);
                var fromu = reader.GetInt32(1);
                var tou = reader.GetInt32(2);
                var msg = reader.GetString(3);
                var crt_Date = reader.GetDateTime(4);
                idmsg.Add(idMsg);
                    Console.WriteLine($"|{idMsg}| {fromu} \n" +
                        $"{tou}: {msg}\n" +
                        $"{crt_Date}");
            }
        }
        public void GetActiveUsers()
        {
            try
            {
                
                const string SqlQuery = "SELECT * FROM dbo.Users";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var userId = reader.GetInt32(0);
                    var userLogin = reader.GetString(1);
                    Console.WriteLine($"{userId} - {userLogin}");
                }
            }
            catch (Exception ex) { Console.WriteLine(String.Format("Error: GetActiveUsers, {0}", ex.Message));}
        }
    }
}
