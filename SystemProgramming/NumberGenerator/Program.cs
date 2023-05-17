int x = 0;
int min = int.Parse(Console.ReadLine());
int max = int.Parse(Console.ReadLine());

    

static bool IsPrime(int number)
{
    for (int i = 2; i < number; i++)
    {
        if (number % i == 0)
            return false;
    }
    return true;
}

void ThredGenerator()
{
    x = 1;
    for (int i = min; i <= max; i++)
    {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
    }
}