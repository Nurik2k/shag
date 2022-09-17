using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeConstruction
{
    internal class Worker:IWorker
    {
        public string name { get; set; }
        public Profession profession { get; set; }
        public double pricePerHour { get; set; }
        public List<Ipart> workLists { get; set; }
        public void PrintSeleryInfo()
        {
            double selory = 0;
            foreach (Ipart item in workLists)
            {
                selory += item.constructionTime.TotalDays + pricePerHour;
            }
            Console.WriteLine("И того зарплата: {0}", selory);
        }
    }
}
