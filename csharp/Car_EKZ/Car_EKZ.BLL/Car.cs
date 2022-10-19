using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public class Car:ICar
    {
        public string CarName { get; set; }
        public string Type { get; set; }
        public int GarageNumber { get; set; }
        public DateTime PublishYear { get; set; }
        public Car( string carName, string type, int garageNumber, int publishYear)
        {
            CarName = carName;
            Type = type;
            GarageNumber = garageNumber;
            PublishYear = new DateTime(publishYear);
        }
    }
}
