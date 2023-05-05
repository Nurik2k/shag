using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sum(587768657));
        }

        static int Sum(int value)
        {
            int result = 0;
            result += value % 10;
            value /= 10;
            if (value > 0)
            {
                result += Sum(value);
            }
            return result;
        }
    }
}
