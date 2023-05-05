using Dapper;
using Lesson_7;
using Microsoft.Data.SqlClient;

namespace Lesson_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ConnectionString = "Server=NURIK;Database=ChatDb;Trusted_Connection=true;Encrypt=false";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            const string SqlQuery = "SELECT * FROM [GroupMessages] ORDER BY [create_date]";
            var groupMessages = sqlConnection.Query<GroupMessage>(SqlQuery).ToList();
            foreach(var groupMessage in groupMessages)
            {
                Console.WriteLine($"{groupMessage.UserId} : {groupMessage.Message} [{groupMessage.CreateDate}]");
            }
        }
        
    }
    public class GroupMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }


    }
}