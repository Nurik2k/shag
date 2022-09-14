using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Parts.com.BLL
{
    public class Salesman
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int GetError { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int ListTovar { get; set; }
    }
}
