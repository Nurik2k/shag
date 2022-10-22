using Microsoft.Data.SqlClient;
namespace Lesson1
{
    internal class Program
    {
        const string ConnectionString = "Server=NURIK;Database=Shop;Trusted_Connection=true;Encrypt=false";
        private static void Main(string[] args)
        {
            const string ConnectionString = "Server=NURIK;Database=Shop;Trusted_Connection=true;Encrypt=false";
            try
            {
                SummaryCost();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
        
        static void SummaryCost()
        {
            try
            {
                const string SqlQuery = "SELECT [name], [price], [quantity] FROM dbo.Shop";
                using var sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(SqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var price = reader.GetInt32(i:1);
                    var quantity = reader.GetInt32(i: 2);
                    var totalPrice = price * quantity;
                    Console.WriteLine($"[name - {name}, total price - {totalPrice} KZT]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}