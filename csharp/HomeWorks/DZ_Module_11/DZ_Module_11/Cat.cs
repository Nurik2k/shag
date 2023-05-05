using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Module_11
{
    public class Cat
    {
        /// <summary>
        /// Текущий уровень насыщения
        /// </summary>
        public int CurrentSatietyState { get; set; }
        /// <summary>
        /// Максимальный уровень насыщения
        /// </summary>
        public int MaxSatietyState { get; set; }
        /// <summary>
        /// Необходимый уровень насыщения
        /// </summary>
        public int NecessarySaturationState { get; set; }

        public Cat()
        {
            //Задаем максимальный уровень насыщения
            MaxSatietyState = 200;
            Random r = new Random();
            //Задаем необходимый уровень насыщения
            NecessarySaturationState = r.Next(MaxSatietyState / 2, MaxSatietyState);
            //Задаем начальный уровень насыщения
            CurrentSatietyState = r.Next(1,
                (MaxSatietyState - NecessarySaturationState) / 2 + NecessarySaturationState);
        }

        public string Eat(Food enter)
        {
            switch (enter)
            {
                case Food.Мышь: return "Кот сожрал мышку";
                case Food.Молоко: return "Кот выпил молоко, уровень сытости";
                case Food.Мясо: return "Кот съел мясо, уровень сытости";
                case Food.Китикэт: return "Кот заточил китикэт, уровень сытости";
                default: return "";
            }
        }
    }
}
