using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public class ShutdownService
    {
        public string Path { get; set; }
        public ShutdownService(string path)
        {
            Path = path;
        }
        public ShutdownService() { }
        public ReturnResult CreateShutdown(Shutdown shutdown)
        {
            ReturnResult result = new ReturnResult();
            using (var db = new LiteDatabase(Path))
            {
                var shutdowns = db.GetCollection<Shutdown>(typeof(Shutdown).Name);
                shutdowns.Insert(shutdown);
            }
            return result;

        }
        public List<Shutdown> GetShutdown()
        {
            List<Shutdown> ListShutdowns = new List<Shutdown>();
            using (var db = new LiteDatabase(Path))
            {
                var shutdowns = db.GetCollection<Shutdown>(typeof(Shutdown).Name);
                ListShutdowns = shutdowns.FindAll().ToList();
            }
            return ListShutdowns;
        }
        public string PrintShutdown(List<Shutdown> ListShutdowns)
        {
            string result = "";
            foreach (var item in ListShutdowns)
            {
                result += item.ToString();
            }
            return result;
        }
    }
}
