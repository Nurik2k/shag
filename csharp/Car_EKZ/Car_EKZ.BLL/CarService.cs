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
                var cars = db.GetCollection<Car>(typeof(Car).Name);
                cars.Insert(car);
            }

            return result;
        }
        public List<Car> GetCars()
        {
            List<Car> ListCar = new List<Car>();
            using (var db = new LiteDatabase(Path))
            {
                var cars = db.GetCollection<Car>(typeof(Car).Name);
                ListCar = cars.FindAll().ToList();
                return ListCar;            
            }

        }
        public string PrintCar(List<Car> Cars)
        {
            string result = "";
                foreach (var item in Cars)
                {
                result += item.ToString();
                }
            return result;
        }
        public Car GetCarID(int carID)
        {
            Car car = new Car();
            List<Car> ListCar = new List<Car>();
            using (var db = new LiteDatabase(Path))
            {
                var cars = db.GetCollection<Car>(typeof(Car).Name);
                ListCar = cars.FindAll().ToList();
                car = ListCar.Find(x => x.CarID == carID);
            }
            return car;
        }
    }
}
