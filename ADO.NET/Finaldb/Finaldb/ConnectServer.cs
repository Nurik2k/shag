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
            const string ConnectionString = "Server=NURIK;Database=ChatDb;Trusted_Connection=true;Encrypt=false";
            return ConnectionString;
        }
    }
}
