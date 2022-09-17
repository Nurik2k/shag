
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeConstruction
{
    internal interface Ipart
    {
        string color { get; set; }
        TimeSpan constructionTime { get; set; }
        int count { get; set; }
        TypeOfMaterial typeOfMaterial { get; set; }
        double priceMaterial { get; set; }
        TimeSpan GetConstructionTime();
        double GetConstructionCost();

    }
}
