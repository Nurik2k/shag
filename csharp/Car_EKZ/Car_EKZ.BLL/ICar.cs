using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public abstract class ICar
    {
        string CarName { get; set; }
        string Type { get; set; }
        int GarageNumber { get; set; }
        DateTime PublishYear { get; set; }

    }
}
