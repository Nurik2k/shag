namespace DZ3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SwitchMenu(ShowMenu());
        }
        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Car");
            Console.WriteLine("2. Edit Information");
            Console.WriteLine("3. Delete Car");
            Console.WriteLine("4. Show All");
            Console.WriteLine("0. Quite");

            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                return 0;
            }

            int number = int.Parse(inputString);
            return number;
        }
        public static void SwitchMenu(int number)
        {
            switch (number)
            {
                case 1:
                    AddNewCar();
                    break;
                    case 2:
                    EditInforamtionCar();
                    break;
                    case 3:
                    DeleteCar();
                    break;
                    case 4:
                    ShowAllCar();
                    break;
                    case 0:
                    Console.Clear();
                    Console.WriteLine("You got out!");
                    break;
            }
        }
        public static void AddNewCar()
        {
            Console.Write("Enter car mark: ");
            var mark = Console.ReadLine();
            Console.Write("Enter car model: ");
            var model = Console.ReadLine();
            Console.Write("Enter car information");
            var information = Console.ReadLine();
            Console.Write("Enter publish year: ");
            var publishYear = Convert.ToInt32(Console.ReadLine());
            var car = new Car()
            {
                Mark = mark,
                Model = model,
                Information = information,
                PublishYear = publishYear
            };
            using var db = new CarContext();
            db.Cars.Add(car);
            db.SaveChanges();
            Console.WriteLine("Added.");
            Thread.Sleep(1500);
            SwitchMenu(ShowMenu());
        }
        public static void EditInforamtionCar()
        {
            Console.Write("Enter ID");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Come on?"));
            using var db = new CarContext();
            var car = db.Cars.First(f => f.Id == id);
            Console.WriteLine("Edit information: ");
            var newInfo = Console.ReadLine();
            car.Information = newInfo;
            db.SaveChanges();
            Console.WriteLine("Edited");
            Thread.Sleep(1500);
            SwitchMenu(ShowMenu());
        }
        public static void DeleteCar()
        {
            Console.Write("Enter ID: ");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Ты че?"));
            using var db = new CarContext();
            var car = db.Cars.First(f => f.Id == id);
            db.Cars.Remove(car);
            db.SaveChanges();
            Console.WriteLine("Deleted!");
            Thread.Sleep(1500);
            SwitchMenu(ShowMenu());
        }
        public static void ShowAllCar()
        {
            using var db = new CarContext();
            var cars = db.Cars.ToList();
            foreach (var car in cars)
            {
                Console.WriteLine($" {car.Id}\n Mark - {car.Mark}\n Model - {car.Model}\n PublishYear - {car.PublishYear}\n Information: \n{car.Information}");
                Console.WriteLine("________________________________________________________________________________________________________________________");
            }
            Console.ReadLine();
            SwitchMenu(ShowMenu());
        }
    }
}