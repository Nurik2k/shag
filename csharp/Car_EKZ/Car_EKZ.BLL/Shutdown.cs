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
        public Component Breakdown { get; set; }
        public string RecommendsForFix { get; set; }
        public User UserSD { get; set; }
        public Shutdown() { }
        public Shutdown(DateTime dateCreat, Car carSD, Component breakdown, string recommendsForFix, User userSD)
        {
            DateCreat = dateCreat;
            CarSD = carSD;
            Breakdown = breakdown;
            RecommendsForFix = recommendsForFix;
            UserSD = userSD;
        }
        public override string ToString()
        {
            return String.Format("Дата создания: {0}" +
                "\nМашина: {1}" +
                "Поломка: {2}" +
                "Рекомендации: {3}\n" +
                "Пользователь: {4}" +
                "_____________________________________________________\n", 
                DateCreat, CarSD, Breakdown, RecommendsForFix, UserSD);
        }
    }
}
