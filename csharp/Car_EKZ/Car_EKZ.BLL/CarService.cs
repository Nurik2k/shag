using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public class CarService
    {
        public string Path { get; set; }
        public CarService(string Path)
        {
            this.Path = Path;
        }
        ReturnResult rr = new ReturnResult();

        /// <summary>
        /// Метод который добавляет машину в Базу данных
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public ReturnResult CreateCar(Car car)
        {

            ReturnResult result = new ReturnResult();

            using (var db = new LiteDatabase(Path))
            {
                var cars = db.GetCollection<Car>("Cars");
                cars.Insert(car);
            }

            return result;
        }
        public List<Car> GetCars(){
            List<Car> ListCar = new List<Car>();
            using (var db = new LiteDatabase(Path))
            {
                var cars = db.GetCollection<Car>("Cars");
                
                foreach (Car item in cars.FindAll())
                {
                    ListCar.Add(item);
                    
                }
                
            }
            return ListCar;
        }
    }
}
