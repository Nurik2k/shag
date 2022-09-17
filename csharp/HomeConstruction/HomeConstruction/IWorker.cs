using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeConstruction
{
    internal interface IWorker
    {
        string name { get; set; }
        Profession profession { get; set; }
        double pricePerHour { get; set; }
        List<Ipart> workLists { get; set; }

    }
}
