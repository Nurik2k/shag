using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finaldb
{
    public class ConnectServer
    {
        public string Connect()
        {
            //UserId=student;Password=123
            const string ConnectionString = "Server=185.213.156.185;Database=ChatDb;User Id=student;Password=123;Encrypt=false;Application Name=Nurik";
            return ConnectionString;
        }
    }
}
