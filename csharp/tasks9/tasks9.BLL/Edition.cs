using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks9.BLL
{
    public abstract class Edition
    {
        public string NameEdition { get; set; }
        public string Adress { get; set; }
        public DateTime Year { get; set; }
        public string Director { get; set; }

        public abstract void GetEditionInfo();
    }
}
