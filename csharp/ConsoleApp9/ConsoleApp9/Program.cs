using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public enum typeOfMateryal {brick=5,wool=56}
    public enum profession { anElectrician,StoneMan, plumber }
    internal class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            house.StartConstruction();

           

            
        }
    }
}
