using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.BLL;

namespace Trans.BLL
{
    public class Car : Transport
    {
        public Car(int ms = 240)
        {
            MaxSpeed = ms;
        }
        public readonly int MaxSpeed;
        public string Brand { get; set; }
        public int Number { get; set; }
        private int speed_;
        public int Speed {
            get 
            { 
            return MaxSpeed;
            }
            set { 
                if(value >= MaxSpeed)
                {
                    throw new Exception("Снизьте скорость!");
                }
                else
                {
                    speed_  = value;
                }
                   
            }
        }

        public override void GetTransInfo()
        {
            string Info = string.Format("Тип транспорта {0}", CarType);
            Console.WriteLine(Info);

            Console.WriteLine(base.WeightInfo());
        }
        //public string LoadCapacity { get; set; }
    }
}
