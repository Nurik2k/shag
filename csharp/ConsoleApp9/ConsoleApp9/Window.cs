using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Window:IPart
    {
        public string color { get; set; }
        public TimeSpan constructionTime { get; set; }
        public int count { get; set; }
        public typeOfMateryal typeOfMateryal { get; set; }
        public double materyalPrice { get; set; }
        public int sort { get; set; } = 4;
        public bool isComplited { get; set; }

        public TimeSpan GetConstructionTime()
        {
            return TimeSpan.FromTicks(constructionTime.Ticks * count);
        }

        public double GetСonstructionСost()
        {
            return materyalPrice * count;
        }
    }
}
