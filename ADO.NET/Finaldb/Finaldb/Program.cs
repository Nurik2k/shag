﻿using Azure.Core;
using Finaldb.Data;
using Finaldb.Models;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace FinalDb
{
    internal class Program
    {
        const string ConnectionString = "Server=NURIK;Database=ChatDb;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {
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
                        Registration(DbContext);
                        break;
                    case 2:
                        string login = "", password = "";
                        Console.Write("Enter login: ");
                        
                            login = Console.ReadLine();
                            Console.Write("Enter password: ");
                            password = Console.ReadLine();
                        
                        

                        SignIn(login, password);
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
        static string HashPass(string pass)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(
                Encoding.UTF8.GetBytes(pass)
            );
            return Convert.ToBase64String(hash);
        }
        static bool SignIn(string login, string password)
        {
            try
            {
                const string SqlQuery = "SELECT [login], [password] FROM dbo.Users WHERE login = @Login";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.Add("Login", SqlDbType.VarChar, 500).Value = login;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var pass = reader.GetString(1);
                    if (HashPass(password) == reader["password"].ToString())
                    {
                        Console.WriteLine("Wellcome!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Password is wrong!");
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }


        }
    }
}
