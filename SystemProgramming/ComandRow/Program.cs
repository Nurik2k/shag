using System;
using System.Text;


Console.Write("Type a message: ");
string message = Console.ReadLine();
using (var file = new FileStream("ConsoleRow.txt", FileMode.OpenOrCreate))
{
    byte[] msg = Encoding.UTF8.GetBytes(message);
    file.Write(msg, 0, msg.Length);
    if (file == null)
    {
        Console.WriteLine("1");
    }
    else
    {
        Console.WriteLine("0");
    }
}



