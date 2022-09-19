using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Teamlid:IWorker
    {
        public string name { get; set; }
        public profession profession { get; set; }
        public double pricePerHour { get; set; }
        public List<IPart> workLists { get; set; }
        public bool isBusy { get; set; }
    }
}
