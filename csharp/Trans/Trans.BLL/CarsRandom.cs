using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.BLL;

namespace Trans.BLL
{
    public class CarsRandom  
    {
        private List<Transport> cars = new List<Transport>();
        public void AddTrans(Transport transport)
        {
            cars.Add(transport);
        }
        public void PrintInfo()
        {
            foreach (Transport item in cars)
            {
                item.GetTransInfo();
            }
        }

    }
}
