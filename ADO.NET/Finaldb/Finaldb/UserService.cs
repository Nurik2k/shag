using Finaldb.Data;
using Finaldb.Models;
using FinalDb;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine(ex.ToString());
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
            
            Menu mn= new Menu();
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
            catch(Exception ex) { Console.WriteLine(ex); }
        }
        public void ShowAllGroups()
        {
            const string SqlQuery = "SELECT * FROM dbo.Groups";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
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
                mn.GetActiveUsers();
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
                mn.GetActiveUsers();
                Console.Write("Enter userID: ");
                var id = Convert.ToInt32(Console.ReadLine());
                var ruser = db.UserGroups.First(f=>f.Id== id);
                db.UserGroups.Remove(ruser); 
                db.SaveChanges();
                Console.Clear();
                Console.WriteLine("Deleted");
                Thread.Sleep(1500);
                mn.UserMenu(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void SendGroupMessage(ChatDbContext db, int id, User fromu)
        {
            try
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
            catch(Exception ex) { Console.WriteLine(ex ); }
        }
    }
}
