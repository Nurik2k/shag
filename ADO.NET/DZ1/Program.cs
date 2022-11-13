using Azure.Core;
using Microsoft.Data.SqlClient;
using System;
namespace DZ1
{
    internal class Program
    {
        const string ConnectionString = "Server=NURIK;Database=Shop;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {
            DbConnection();
                AllProductsName();
                AllColors();
                MaxColories();
                MinColories();
                MedColories();
        }



        static void DbConnection()
        {
            
            try
            {
                const string SqlQuery = "SELECT [ProductName], [Type], [Color], [Colories] FROM dbo.Products";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();
                
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    var Type = reader["Type"].ToString();
                    var Color = reader["Color"].ToString(); 
                    var Colories = reader.GetInt32(i: 3);
                    Console.WriteLine($"|ProductName - {ProductName}|Type - {Type}|Color - {Color}|Colories - {Colories}|");
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void AllProductsName() 
        {
            try
            {
                const string SqlQuery = "SELECT [ProductName] FROM dbo.Products";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    
                    Console.WriteLine($"ProductName - {ProductName}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void AllColors()
        {
            try
            {
                const string SqlQuery = "SELECT [Color] FROM dbo.Products";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Color = reader["Color"].ToString();
                    Console.WriteLine($"Color - {Color}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void MaxColories()
        {
            try
            {
                const string SqlQuery = "SELECT [Colories] FROM dbo.Products";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();
                int max = 0;
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Colories = reader.GetInt32(i: 0);
                    if(Colories > max)
                    {
                        max = Colories;
                    }
                    
                }
                Console.WriteLine($"MaxColories - {max}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void MinColories()
        {
            try
            {
                const string SqlQuery = "SELECT [Colories] FROM dbo.Products";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();
                int min = 10000;
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Colories = reader.GetInt32(i: 0);
                    if (Colories < min)
                    {
                        min = Colories;
                    }

                }
                Console.WriteLine($"MinColories - {min}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void MedColories()
        {
            try
            {
                const string SqlQuery = "SELECT [Colories] FROM dbo.Products";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();
                
                
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                int temp = 0;
                List<int> avg = new List<int>();
               
                    while (reader.Read())
                    {
                        var Colories = reader.GetInt32(i: 0);

                    avg.Add(Colories);
                    }
                foreach(var item in avg)
                {
                    temp += item;
                }
                Console.WriteLine($"Colories - {temp / avg.Count}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
