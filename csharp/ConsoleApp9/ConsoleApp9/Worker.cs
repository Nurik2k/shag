using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Worker : IWorker
    {
        public string name { get; set; }
        public profession profession { get; set; }
        public double pricePerHour { get; set; }
        public List<IPart> workLists { get; set; }
        public bool isBusy { get; set; }
        
        public void PrintSeloryInfo()
        {
            double selory = 0;
            foreach (IPart item in workLists)
            {
               selory += item.constructionTime.TotalHours * pricePerHour;
            }
            Console.WriteLine("{0} {1:#,0.00} тенге", name, selory);
            Console.WriteLine("Объем выполнненых работ {0}", workLists.Count);
        }
    }
}
