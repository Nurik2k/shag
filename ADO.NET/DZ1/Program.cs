using Microsoft.Data.SqlClient;
using System;
namespace DZ1
{
    internal class Program
    {
        const string ConnectionString = "Server=NURIK;Database=Shop;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {
            ShowNameProduct();
        }

// Отображение всей информации из таблицы с овощами и фруктами;
//Отображение всех названий овощей и фруктов;
// Отображение всех цветов;
//Домашнее задание
// Показать максимальную калорийность;
// Показать минимальную калорийность;
// Показать среднюю калорийность.

        static void DbConnection()
        {
            
            try
            {
                const string SqlQuery = "SELECT [ProductName], [Type], [Color], [Colories] FROM dbo.Products";
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
        static void ShowNameProduct()
        {
            try
            {
                const string SqlQuery = "SELECT [ProductName], [Type], [Color], [Colories] dbo.Products";
                using var conn = new SqlConnection(ConnectionString);
                conn.Open();
                Console.WriteLine("AOAOA");
                using var SqlCommand = new SqlCommand(SqlQuery, conn);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    
                    Console.WriteLine($"ProductName - {ProductName}\n");
                }

            }
                catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}