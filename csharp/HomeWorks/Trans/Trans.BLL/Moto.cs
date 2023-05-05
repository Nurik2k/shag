using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.BLL;

namespace Trans.BLL
{
    public class Moto: Transport
    {
        public Moto(int CarWeight, int MaxWeight) : base(CarWeight, MaxWeight)
        {

        }
        public Moto(string motoType, string motoNumber, int motoSpeed, bool wheelChairs)
        {
            MotoType = motoType;
            MotoNumber = motoNumber;
            MotoSpeed = motoSpeed;
            WheelChairs = wheelChairs;
        }

        public string MotoType { get; set; }
        public string MotoNumber { get; set; }
        public int MotoSpeed { get; set; }
        public bool WheelChairs { get; set; }

        public override void GetTransInfo()
        {
            Console.WriteLine("-");
        }
        public override string WeightInfo()
        {
            return string.Format("Грузоподьемность равна: {0}", (MaxWeight - Weight)/0.25);

        }
        //public override double WeightParam()
        //{
        //    //return base.WeightParam() / 0.25;
        //    return MaxWeight / 0.25;
        //}
    }
}
