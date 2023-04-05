using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Structural.Facade
{
    class Compiler
    {
        public void Checking()
        {
            Console.WriteLine("Прочитать файл");
            Console.WriteLine("Провести синтаксический анализ");
        }
        public void Parse()
        {
            Checking();
            Console.WriteLine("Выполнить обработку ошибок");
        }
        public void Сompile()
        {
            Parse();
            Console.WriteLine("Добавление отладочной информации");
            Console.WriteLine("Добавление динамических библиотек");
            Console.WriteLine("Компиляция");
        }
    }
}
