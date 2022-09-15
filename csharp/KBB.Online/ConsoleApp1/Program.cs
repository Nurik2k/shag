using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Counter counter = new Counter;
            //int c = (int)counter;
            Money money1 = new Money(100, "USD");
            Money money2 = new Money(300, "USD");
            Console.WriteLine();
            Money money3 = money1 + money2;
            Number num = (Number)money1;
            var data = "";
        }
    }
    public class Number
    {
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public int SomeValue { get; set; }
        public static explicit operator Number(Money m)
        {
            return new Number { Amount = m.Amount};
        }
        //public static implicit operator Number(Money m); 
    }

    public class Money
    {
        public decimal Amount { get; set; }
        public string Unit { get; set; }
        public Money(decimal amount, string unit)
        {
            this.Amount = amount;
            this.Unit = unit;
        }
        public static Money operator +(Money a, Money b)
        {
            if (a.Unit != b.Unit) throw new InvalidOperationException("Нельзя");
            return new Money(a.Amount + b.Amount, a.Unit);
        }
        public override string ToString()
        {
            return String.Format("{0} - {1}", this.Amount, this.Unit);
        }
        public override bool Equals(object obj)
        {
            return ((Money)obj).Amount == this.Amount;
        }
        public static bool operator ==(Money a, Money b)
        {
            return a.Amount == b.Amount;
        }
        public static bool operator !=(Money a, Money b){
            return a.Amount != b.Amount;
        }
    }

    public class Counter
    {
        public int Second { get; set; }

        public static implicit operator Counter(int x)
        {
            return new Counter { Second = x };
        }

        public static explicit operator int(Counter counter)
        {
            return counter.Second;
        }
    }
}
