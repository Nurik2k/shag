using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeConstruction
{
    public class Roof:Ipart
    {
        public string color { get; set; }
        public TimeSpan constructionTime { get; set; }
        public int count { get; set; }
        public TypeOfMaterial typeOfMaterial { get; set; }
        public double priceMaterial { get; set; }
        public TimeSpan GetConstructionTime()
        {
            return TimeSpan.FromTicks(constructionTime.Ticks * count);
        }
        public double GetConstructionCost()
        {
            return priceMaterial * count;
        }
    }
}
