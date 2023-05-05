using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Module_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat myCat = new Cat();
            Console.WriteLine("Максимальный уровень насыщения: {0}", myCat.MaxSatietyState);
            Console.WriteLine("Текущий уровень насыщения: {0}", myCat.CurrentSatietyState);
            Console.WriteLine("Для завершения кормления введите \"Выход\"");

            Food anyfood = Food.Молоко;
            do
            {
                Console.WriteLine("Что хочет скушать кот?\n Мышь\n Молоко\n Мясо\n Китикэт");
                string enter = Console.ReadLine();
                anyfood = (Food)Enum.Parse(typeof(Food), enter);
                myCat.CurrentSatietyState += Convert.ToInt32(anyfood);

                Console.WriteLine(myCat.Eat(anyfood) + ", уровень сытости: " + myCat.CurrentSatietyState);

                if (myCat.CurrentSatietyState > myCat.MaxSatietyState)
                {
                    Console.WriteLine("Надо срочно худеть. Кот будет худеть? Да/Нет ");
                    var yes = Console.ReadLine();
                    if (yes == "Да")
                    {
                        myCat.CurrentSatietyState = 10;
                        Console.WriteLine("Уровень сытости: " + myCat.CurrentSatietyState);
                    }
                    else
                    {
                        Console.WriteLine("Игра окончена");
                        anyfood = Food.Выход;
                    }
                }
            } while (anyfood != Food.Выход);
        }
    }

    


}
