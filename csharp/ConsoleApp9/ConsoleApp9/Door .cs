using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Door : IPart
    {
        public string color { get; set; }
        public TimeSpan constructionTime { get; set; }
        public int count { get; set; }
        public typeOfMateryal typeOfMateryal { get; set; }
        public double materyalPrice { get; set; }
        public int sort { get; set; } = 3;
        public bool isComplited { get; set; }

        public System.Nullable<int> TypeDoor = null;

        public TimeSpan GetConstructionTime()
        {
            int data = TypeDoor ?? 0;

            if (TypeDoor== null)
            {
                data = 0;
            }

            return TimeSpan.FromTicks(constructionTime.Ticks * count);
        }

        public double GetСonstructionСost()
        {
            return materyalPrice * count;
        }
    }
}
