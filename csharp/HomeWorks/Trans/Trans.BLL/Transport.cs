using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.BLL
{
    public abstract class Transport
    {
        public Transport() : this( 0, 0)
        {

        }
        public Transport(int MaxWeight, int Weight)
        {
            this.MaxWeight = MaxWeight;
            this.Weight = Weight;
        }
        public string CarType { get; set; }
        public int Weight { get; set; }
        public int MaxWeight { get; set; }

        public abstract void GetTransInfo();

        public virtual string WeightInfo()
        {
            return string.Format("Грузоподъёмность = {0}", MaxWeight - Weight);
        }
    }
}
