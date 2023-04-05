using System;

namespace DesingPattarns.MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            MVCModel model = new MVCModel();
            while (model.Start()) { }
        }
    }
}
