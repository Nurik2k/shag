using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kakayaraznica
{
    public class TimeForm
    {
        public static string NowDateTime()
        {
            return $"{DateTime.Now:MM/dd/yy H:mm:ss zzz}";
        }
    }
}
