using Finaldb.Data;
using Finaldb.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public List<int> idmsg = new List<int>();
        public void MainMenu()
        {
            UserService userService = new UserService();
            using var DbContext = new ChatDbContext();
            try
            {
                Console.Clear();
                bool isDebug = true;

                Console.WriteLine("Select menu item:");
                Console.WriteLine("1. Registration");
                Console.WriteLine("2. Sign in");
                Console.WriteLine("0. Quit");
                int ch = Int32.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.Clear();
                        userService.Registration(DbContext);
                        break;
                    case 2:
                        Console.Clear();
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
                    case 0:
                        Console.Clear();
                        Console.WriteLine("You are quit!");
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
            Console.Clear();
            UserService users = new UserService();
            using var DbContext = new ChatDbContext();
            Group group = new Group();

            if (user != null)
            {
                Console.WriteLine("1. Send message to user");
                Console.WriteLine("2. Show messages");
                Console.WriteLine("3. Group");
                Console.WriteLine("4. Show users");
                Console.WriteLine("5. Delete user");
               
                Console.WriteLine("0. Log out");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        GetActiveUsers(user);
                        Console.Write("Enter id: ");
                        int tou = int.Parse(Console.ReadLine());
                        SendMessage(user, tou, DbContext);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        GetActiveUsers(user);
                        Console.Write("Enter id: ");
                        user.Id = int.Parse(Console.ReadLine());
                        ShowMessage(user.Id);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        GroupMenu(user);
                        break;
                        case 4:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        GetActiveUsers(user);
                        break;
                        case 5:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        users.DeleteUser(DbContext,user);
                        break;
                    

                       
                    case 0:
                        Console.Clear();
                        MainMenu();
                        break;

                }
            }
        }
        public void SendMessage(User fromu, int tou, ChatDbContext db)
        {
            try
            {
                Console.Clear();
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
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        public void ShowMessage(int id)
        {

            while (true)
            {
                Console.Clear();
                const string SqlQuery = "SELECT * FROM dbo.PrivateMessages WHERE to_user_id = @id or from_user_id = @id";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.AddWithValue("id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
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

                    Thread.Sleep(1000);
                }
            }
        }
        public void ShowGroupMessage(int id)
        {
            while (true)
            {
                Console.Clear();
                const string SqlQuery = "SELECT [login], [message], [create_date] FROM dbo.GroupMessages JOIM Users ON GroupMessages.user_id = Users.id WHERE group_id = @group_id";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.AddWithValue("@group_id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var login = reader["login"].ToString();
                        var message = reader["message"].ToString();
                        var crd = reader.GetDateTime(2);
                        Console.WriteLine($"{login}: {message} [{crd}]");
                    }
                    Thread.Sleep(1000);
                }
            }
        }
        public void GetActiveUsers(User user)
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
                catch (Exception ex) { Console.WriteLine(String.Format("Error: GetActiveUsers, {0}", ex.Message)); }
            }
            public void GroupMenu(User user)
            {
                UserService users = new UserService();
                using var DbContext = new ChatDbContext();
                Group group = new Group();
                Console.Clear();
                Console.WriteLine($"Hello, {user.Login}");
                Console.WriteLine("_______________________");
                Console.WriteLine("1. Add group");
                Console.WriteLine("2. Show groups");
                Console.WriteLine("3. Add user to group");
                Console.WriteLine("4. Send group msg");
                Console.WriteLine("5. Remove user from group");
                Console.WriteLine("6. Delete group");
                Console.WriteLine("7. Show users in group");
                Console.WriteLine("8. Show group msg");
                Console.WriteLine("0. Back");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {

                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        users.AddGroup(DbContext, user);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        users.CheckUsersGroupsIds(user);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        users.ShowAllGroups();
                        Console.Write("Enter groupID: ");
                        var id = int.Parse(Console.ReadLine());
                        users.AddUserToGroup(DbContext, id);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        users.ShowAllGroups();
                        Console.Write("Enter groupID: ");
                        var id1 = int.Parse(Console.ReadLine());
                        users.SendGroupMessage(DbContext, id1, user);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        users.ShowAllGroups();
                        Console.Write("Enter groupID: ");
                        var id2 = int.Parse(Console.ReadLine());
                        users.RemoveUserFromGroup(DbContext, id2);
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        users.DeleteGroup(DbContext, user);
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        Console.Write("Enter group id: ");
                        var idg = int.Parse(Console.ReadLine());
                        users.UserInGroup1(DbContext, idg);
                        break;
                    case 8:
                    Console.Clear();
                    Console.WriteLine($"Hello, {user.Login}");
                    Console.WriteLine("_______________________");
                    Console.WriteLine("Enter group id: ");
                        var idd = int.Parse(Console.ReadLine());
                    ShowGroupMessage(idd);
                    break;
                case 0:
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        UserMenu(user);
                        break;

                }
            }
        }
    }
