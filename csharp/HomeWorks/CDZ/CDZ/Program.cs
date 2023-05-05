using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDZ
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Array array = new Array(10);
            array[5] = 4;
            Console.WriteLine(array[5]);
            

        }
    }
    public class Array
    {
        int[] arr;

        public Array(int size) => arr = new int[size];

        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value * value; }
        }
    }
}
