using Finaldb.Data;
using Finaldb.Models;
using FinalDb;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Finaldb.Models.Group;

namespace Finaldb
{
    public class UserService
    {
        ConnectServer connect = new ConnectServer();

        public void Registration(ChatDbContext db)
        {

            Menu mn = new Menu();
            try
            {
                User newUser = new User();
                Console.Write("Enter login: ");
                newUser.Login = Console.ReadLine();
                Console.Write("Enter password: ");
                newUser.Password = HashPass(newUser.Password = Console.ReadLine());
                db.Users.Add(newUser);
                db.SaveChanges();
                Console.WriteLine("Added!");
                mn.UserMenu(newUser);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex);
            }
        }
        public string HashPass(string pass)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(
                Encoding.UTF8.GetBytes(pass)
            );
            return Convert.ToBase64String(hash);
        }
        public void SignIn(string login, string password)
        {

            Menu mn = new Menu();
            try
            {
                const string SqlQuery = "SELECT [id] [login], [password] FROM dbo.Users WHERE login = @Login";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.Add("Login", SqlDbType.VarChar, 500).Value = login;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var pass = reader["password"].ToString();
                    if (pass == HashPass(password))
                    {
                        var user = new User()
                        {
                            Id = reader.GetInt32(0),
                            Login = login,
                            Password = password
                        };
                        Console.Clear();
                        Console.WriteLine($"Hello, {user.Login}");
                        Console.WriteLine("_______________________");
                        mn.UserMenu(user);
                    }
                    else
                    {
                        Console.WriteLine("Password is wrong!");
                    }
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


        }
        public void AddGroup(ChatDbContext db, User user)
        {
            Menu mn = new Menu();
            try
            {
                Group group = new Group();
                Console.Write("Enter group name: ");
                group.Name = Console.ReadLine();
                group.OwnerId = user.Id;
                db.Groups.Add(group);
                db.SaveChanges();
                Console.WriteLine("Added!");
                Thread.Sleep(1500);
                mn.UserMenu(user);
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        public void DeleteGroup(ChatDbContext db, User user)
        {
            Group group = new Group();
            Menu mn = new Menu();
            try
            {
                ShowAllGroups();
                Console.Write("Enter id: ");
                var id = Convert.ToInt32(Console.ReadLine());
                var rgroup = db.Groups.First(g => g.Id == id);
                db.Groups.Remove(rgroup); 
                db.SaveChanges();
                Console.WriteLine("Deleted!");
                Thread.Sleep(1500);
                mn.GroupMenu(user);
            }
            catch (Exception ex) { Console.WriteLine("You cant bitch!"); Thread.Sleep(1500); Console.Clear(); mn.GroupMenu(user); }
        }
        public void ShowAllGroups()
        {
            const string SqlQuery = "SELECT * FROM dbo.Groups";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader["name"].ToString();
                var ownerId = reader.GetInt32(2);
                Console.WriteLine($"|{id}|{name}|{ownerId}|");
            }
        }
        public void ShowUserInGroup()
        {
            const string SqlQuery = "SELECT * FROM dbo.UserGroups";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();

        }
        public void AddUserToGroup(ChatDbContext db, int id)
        {
            UserGroup ug = new UserGroup();
            Menu mn = new Menu();
            User user = new User();
            try
            {
                ug.GroupId = id;
                mn.GetActiveUsers(user);
                Console.Write("Enter userID: ");
                user.Id = Convert.ToInt32(Console.ReadLine());
                ug.UserId = user.Id;
                db.UserGroups.Add(ug);
                db.SaveChanges();
                Console.WriteLine("Added!");
                Thread.Sleep(1500);
                mn.UserMenu(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void RemoveUserFromGroup(ChatDbContext db, int id2)
        {
            UserGroup ug = new UserGroup();
            Menu mn = new Menu();
            User user = new User();
            try
            {
                ug.GroupId = id2;
                UserInGroup1(db, id2);
                Console.Write("Enter userID: ");
                var id = Convert.ToInt32(Console.ReadLine());
                var ruser = db.UserGroups.First(f => f.Id == id);
                db.UserGroups.Remove(ruser);
                db.SaveChanges();
                Console.Clear();
                Console.WriteLine("Deleted");
                Thread.Sleep(1500);
                mn.GroupMenu(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public bool UserInGroups(User user) 
        {
            const string SqlQuery = "SELECT [user_id] FROM dbo.UserGroups";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var UID = reader.GetInt32(0);
                if(user.Id == UID)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Not in group");
                    return false;
                }
               
            }
            return true;
        }
        public void SendGroupMessage(ChatDbContext db, int id, User fromu)
        {
            Menu mn = new Menu(); 
            try
            {
                if (IsUserInGroup(fromu))
                {
                    while (true)
                    {
                        GroupMessage gr = new GroupMessage();
                        gr.GroupId = id;
                        gr.UserId = fromu.Id;
                        Console.Write("!:");
                        gr.Message = Console.ReadLine();
                        gr.CreateDate = DateTime.Now;
                        db.GroupMessages.Add(gr);
                        db.SaveChanges();
                        Console.WriteLine($"|{gr.GroupId}|{gr.UserId}|\n|{gr.Message}|\n|{gr.CreateDate}|");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You are not in this group!");
                    mn.UserMenu(fromu);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }
        public int GetGroupId(string GroupName)
        {
            try
            {
                int result = new();
                const string SqlQuery = "SELECT id FROM dbo.Groups WHERE name = @groupName";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.AddWithValue("@groupName", GroupName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                return result;
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: Getting Group Id {0}", ex.Message); return 0; }
        }
        public bool IsUserInGroup(User user)
        {
            try
            {
                const string SqlQuery = "SELECT id FROM dbo.UserGroups WHERE group_id = @groupId AND user_id = @userId";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                
                cmd.Parameters.AddWithValue("@userId", user.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    reader.GetInt32(0);
                    counter++;
                }
                if (counter != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: cheching groups contain user"); Thread.Sleep(5000); return true; }
        }
        public void CheckUsersGroupsIds(User user)
        {
            try
            {
                const string SqlQuery = "SELECT [group_id], [name] FROM UserGroups JOIN Groups ON UserGroups.group_id = Groups.id WHERE user_id = @user_id;";
                using SqlConnection connection = new SqlConnection(connect.Connect());
                connection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@user_id", user.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var groups = reader.GetInt32(0);
                    var groupname = reader["name"].ToString();
                    Console.WriteLine($"{groups}: {groupname}");
                    
                }
               
            
            
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: checking groups {0}", ex.Message); }
        }
       public void UserInGroup1(ChatDbContext db, int idg)
        {
            const string SqlQuery = "SELECT [group_id], [user_id], [login] FROM UserGroups JOIN Users ON UserGroups.user_id = Users.id JOIN Groups ON Groups.id = UserGroups.group_id WHERE group_id = @group_id";
            using SqlConnection connection = new SqlConnection(connect.Connect());
            connection.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@group_id", idg);
           SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var group_id = reader.GetInt32(0);
                var user_id = reader.GetInt32(1);
                var login = reader["login"].ToString();
                Console.WriteLine($"[{group_id}] [{user_id}]: [{login}]");
            }
        }
        public void DeleteUser(ChatDbContext db, User user)
        {
            Menu mn = new Menu();
            try
            {
                mn.GetActiveUsers(user);
                Console.Write("Enter userID: ");
                var id = Convert.ToInt32(Console.ReadLine());
                var ruser = db.Users.First(f => f.Id == id);
                db.Users.Remove(ruser);
                db.SaveChanges();
                Console.Clear();
                Console.WriteLine("Deleted");
                Thread.Sleep(1500);
                mn.MainMenu();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Nelzya!", ex.Message);
            }
        }
        
    }
}

