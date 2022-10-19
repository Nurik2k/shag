using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public class Car:ICar
    {
        public enum Status { available, notAvailable}
        public int CarID { get; set; }
        public string CarModel { get; set; }
        public string CarName { get; set; }
        public string Type { get; set; }
        public int GarageNumber { get; set; }
        public DateTime PublishYear { get; set; }
        public Car()
        {

        }
        public Car( string carModel,string carName, string type, int garageNumber, int publishYear)
        {
            CarModel = carModel;
            CarName = carName;
            Type = type;
            GarageNumber = garageNumber;
            PublishYear = new DateTime(publishYear);
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", CarModel, CarName, Type, GarageNumber);

        }
    }
}
