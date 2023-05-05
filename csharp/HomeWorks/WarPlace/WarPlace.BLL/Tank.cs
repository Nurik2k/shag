using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarPlace.BLL
{
    public class Tank
    {
        protected string name;
        protected int boekomplekt;
        protected int lvlBroni;
        protected int lvlManevr;
        public Tank(int boekomplekt, int lvlBroni, int lvlManevr, string name)
        {

            this.boekomplekt = boekomplekt;
            this.lvlBroni = lvlBroni;
            this.lvlManevr = lvlManevr;
            this.name = name;
        }
        public Tank()
        {
            boekomplekt = 0;
            lvlBroni = 0;
            lvlManevr = 0;
            name = "null";
        }
        public void Print()
        {
            Console.WriteLine("Танк - " + name);
            Console.WriteLine("Боекомплект = " + boekomplekt + ", Броня = " + lvlBroni + ", Маневренность = " + lvlManevr);
        }

        public static Tank operator *(Tank T34, Tank pantera)
        {
            if (T34.boekomplekt > pantera.boekomplekt && T34.lvlBroni > pantera.lvlBroni)
            {
                return T34;
            }
            if (T34.boekomplekt > pantera.boekomplekt && T34.lvlManevr > pantera.lvlManevr)
            {
                return T34;
            }
            if (T34.lvlBroni > pantera.lvlBroni && T34.lvlManevr > pantera.lvlManevr)
            {
                return T34;
            }
            else
            {
                return pantera;
            }
        }
    }
}

  

