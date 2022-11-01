using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace Lesson2
{
    internal class Program
    {
        const string ConnectionString = "Server=NURIK;Database=Shag;Trusted_Connection=true;Encrypt=false";
        private static void Main(string[] args)
        {
            Students();
        }
        static void Students()
        {
            try
            {
                const string SqlQuery = "SELECT [Surename], [Name], [Last_Name], [AVG], [Min], [Max], [Group_Name] FROM dbo.Students";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var surname = reader["Surename"].ToString();
                    var name = reader["Name"].ToString();
                    var last_name = reader["Last_Name"].ToString();
                    var min = reader.GetInt32(i:4);
                    var max = reader.GetInt32(i:5);
                    var AVG = min + max / 2;
                    var group_name = reader["Group_Name"].ToString();
                    Console.WriteLine($"Group_Name - {group_name}\nSurname - {surname}\nName - {name}\nLast_name - {last_name}\nMin - {min}\nMax - {max}\nAVG - {AVG}\n____________________");
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}