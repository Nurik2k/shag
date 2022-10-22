using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public class Shutdown
    {
        public DateTime DateCreat { get; set; }
        public Car CarSD { get; set; }
        public string Breakdown { get; set; }
        public string RecommendsForFix { get; set; }
        public User UserSD { get; set; }
        public Shutdown() { }
        public Shutdown(DateTime dateCreat, Car carSD, string breakdown, string recommendsForFix, User userSD)
        {
            DateCreat = dateCreat;
            CarSD = carSD;
            Breakdown = breakdown;
            RecommendsForFix = recommendsForFix;
            UserSD = userSD;
        }
        public override string ToString()
        {
            return String.Format("{0} {0}  {0} {0} {0}\n", DateCreat, CarSD, Breakdown, RecommendsForFix, UserSD);
        }
    }
}
