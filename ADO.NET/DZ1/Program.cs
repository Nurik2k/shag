using Microsoft.Data.SqlClient;
using System;
namespace DZ1
{
    internal class Program
    {
        const string ConnectionString = "Server=NURIK;Database=Shop;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {
            
        }
        static void DbConnection()
        {
            
            try
            {
                const string SqlQuery = "SELECT [ProductName] [Type] [Color] [Colories]";
                using var conn = new SqlConnection(ConnectionString);
                conn.Open();
                Console.WriteLine("AOAOAO");
                using var SqlCommand = new SqlCommand(SqlQuery, conn);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    var Type = reader["Type"].ToString();
                    var Color = reader["Color"].ToString();
                    var Colories = reader.GetInt32(i: 3);
                    Console.WriteLine($"|ProductName - {ProductName}|Type - {Type}|Color - {Color}|Colories - {Colories}|\n");
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}