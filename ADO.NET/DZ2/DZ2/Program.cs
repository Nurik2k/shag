using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace DZ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu(ShowMenu());
        }
        public static void Menu(int number)
        {
            
            switch(number)
            {
                case 1:
                    Console.Clear();
                    AddNewStock();
                    break;
                case 2:
                    Console.Clear();
                    UpdateStock();
                    break;
                case 3:
                    Console.Clear();
                    DeleteStock();
                    break;
                case 4:
                    Console.Clear();
                    ShowAllStock();
                    break;
                    case 0:
                    Console.Clear();
                    Console.WriteLine("You got out!");
                    break;
            }

        }
        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Select an item:");
            Console.WriteLine("1. Add Stock");
            Console.WriteLine("2. Edit Stock");
            Console.WriteLine("3. Delete Stock");
            Console.WriteLine("4. Show all");
            Console.WriteLine("0. Quite");

            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                return 0;
            }

            int number = int.Parse(inputString);
            return number;
        }

        static void ShowAllStock()
        {
            using var db = new StockContext();
            var stocks = db.Stocks.ToList();
            foreach(var stock in stocks)
            {
                Console.WriteLine($"|{stock.Id}| Product - {stock.Product}| Type - {stock.Type}| Provider - {stock.Provider}|");
            }
            Console.ReadLine();
            Menu(ShowMenu());
        }

        static void AddNewStock()
        {
            Console.Write("Enter a product: ");
            string product = Console.ReadLine();
            Console.Write("Enter type: ");
            string type = Console.ReadLine();
            Console.Write("Enter provider: ");
            string provider = Console.ReadLine();

            var stock = new Stock()
            {
                Product = product,
                Type = type,
                Provider = provider
            };
            using var db = new StockContext();
            db.Stocks.Add(stock);
            db.SaveChanges();
            Console.BackgroundColor= ConsoleColor.Green;
            Console.WriteLine("Added.");
            Thread.Sleep(1500);
            Menu(ShowMenu());
        }
        static void UpdateStock()
        {
            Console.Write("Enter ID: ");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Come on?"));
            using var db = new StockContext();
            var stock = db.Stocks.First(f => f.Id == id);
            Console.WriteLine("Edit Product: ");
            var newProduct = Console.ReadLine();
            Console.WriteLine("Edit Type: ");
            var newType = Console.ReadLine();
            Console.WriteLine("Edit Provider: ");
            var newProvider = Console.ReadLine();
            stock.Product = newProduct;
            stock.Type = newType;
            stock.Provider = newProvider;
            db.SaveChanges();
            Console.BackgroundColor= ConsoleColor.Green;
            Console.WriteLine("Changes saved.");
            Thread.Sleep(1500);
            Menu(ShowMenu());
        }
        static void DeleteStock()
        {
            Console.Write("Enter ID: ");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Come on?"));
            using var db = new StockContext();
            var stock = db.Stocks.First(f => f.Id == id);
            db.Stocks.Remove(stock);
            db.SaveChanges();
            Console.BackgroundColor= ConsoleColor.Green;
            Console.WriteLine("Deleted.");
            Thread.Sleep(1500);
            Menu(ShowMenu());
        }
    }
}