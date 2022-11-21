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
    }
}
