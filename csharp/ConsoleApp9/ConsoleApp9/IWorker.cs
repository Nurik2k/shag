using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public interface IWorker
    {
        string name { get; set; }
        profession profession { get; set; }
        double pricePerHour { get; set; }
        List<IPart> workLists { get; set; }
        bool isBusy { get; set; }
    }
}
