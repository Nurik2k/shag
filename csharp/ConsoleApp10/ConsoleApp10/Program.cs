using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
namespace ConsoleApp10
{
    internal class Program
    {
        delegate void GetMessage();
        delegate int Operation(int x, int y);
        static void Main(string[] args)
        {
            ////Создаем переменую делегата
            //Class1 cl = new Class1();
            //if(DateTime.Now.Hour < 12)
            //{
            //    cl.ShowMessage(GoodMorning);
            //}
            //else
            //{
            //    cl.ShowMessage(GoodEvening);
            //}
            //_______________________________________
            //Operation del = new Operation(Add);
            //int result = del.Invoke(4, 5);

            //ShowMessage(GoodMorning);
            //_______________________________________
            Account account = new Account(200, 6);
            account.RegisterHendler(PrintMessage);
            account.WithDraw(500);
        }
        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Multiple(int x, int y)
        {
            return x * y;
        }

        private static void ShowMessage(GetMessage delM)
        {
            delM.Invoke();
        }
        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");

        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }
        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Account
    {
        int _sum;
        int _percentage;

        public Account(int sum, int percentage)
        {
            _sum = sum;
            _percentage = percentage;
        }
        public delegate void AccountStateHendler(string message);
        AccountStateHendler del;
        public void RegisterHendler(AccountStateHendler _del)
        {
            del = _del;
        }
        public int CurrentSum
        {
            get { return _sum; }
        }
        public void Put(int sum)
        {
            _sum += sum;
        }
        public void WithDraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;
                if (del != null)
                {
                    del("Сумма " + sum + " снята с вашего счета");
                }
            }
            else
            {
                if (del != null) del("Недостаточно средств");
            }

        }
    }
}
