using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson011._2
{
    
    public enum Status { on, off}
    [Serializable]
    public class PC
    {
        public string Brand { get; set; }
        public string serialNumber { get; set; }
        public int Price { get; set; }
        public PC(string brand, string serialNumber, int price)
        {
            Brand = brand;
            this.serialNumber = serialNumber;
            Price = price;
        }
        public void StatusPC(Status s)
        {
            Console.Write(s.ToString());
            Console.WriteLine();
        }
    }
}
