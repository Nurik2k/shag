using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.MVC
{
    enum TLight { RED, YELLOW, GREEN}
    class MVCView
    {
        private MVCController _controller;
        public MVCView(MVCController controller)
        {
            _controller = controller;
        }
        public void Show(TLight clr)
        {
            Console.Clear();
            ConsoleColor defColor = Console.ForegroundColor;
            switch (clr)
            {
                case TLight.RED:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("traffic light");
                    Console.ForegroundColor = defColor;
                    Console.WriteLine("traffic light");
                    Console.WriteLine("traffic light");
                    break;
                case TLight.YELLOW:
                    Console.WriteLine("traffic light");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("traffic light");
                    Console.ForegroundColor = defColor;
                    Console.WriteLine("traffic light");
                    break;
                case TLight.GREEN:
                    Console.WriteLine("traffic light");
                    Console.WriteLine("traffic light");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("traffic light");
                    Console.ForegroundColor = defColor;
                    break;
                default:
                    Console.WriteLine("traffic light");
                    Console.WriteLine("traffic light");
                    Console.WriteLine("traffic light");
                    break;
            }
            Console.WriteLine("");
            Console.Write("Enter \"next\": ");
            _controller.Get();
        }
    }
    class MVCController
    {
        private MVCModel _model;
        public MVCController(MVCModel model)
        {
            _model = model;
        }
        public void Get()
        {
            string answer = Console.ReadLine();
            if (answer.Equals("next"))
            {
                _model.Next();
            }
            else if (answer.Equals("exit"))
            {
                _model.Exit();
            }
        }
    }
    class MVCModel
    {
        private TLight _current;
        private bool isRun;
        public MVCModel()
        {
            _current = TLight.RED;
            isRun = true;
        }
        public bool Start()
        {
            MVCView view = new MVCView(new MVCController(this));
            view.Show(_current);
            return isRun;
        }
        public void Next()
        {
            if (_current == TLight.RED)
            {
                _current = TLight.YELLOW;
            }
            else if (_current == TLight.YELLOW)
            {
                _current = TLight.GREEN;
            }
            else if (_current == TLight.GREEN)
            {
                _current = TLight.RED;
            }
        }
        public void Exit()
        {
            isRun = false;
        }
    }
}

/*
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
 */
