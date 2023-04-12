//Переписать класс ведения журнала регистрации с использованием паттернов.
//1. Добавить возможность записи различных типов сообщений в отдельные файлы.
//2. Добавить возможность добавления типов записей.
//3. Сократить количество используемых методов.
using kakayaraznica;
using System.Diagnostics;
class CSharp
{
    static void Main()
    {
        LoggerSingleton.GetInstance();

        for (var i = 0; i < 10; i++)
        {
            WriteErrors.WriteError($"test {i}", true);
        }
        Console.WriteLine("< END >");
        Console.ReadLine();
    }
}

