using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.Template_Method
{
    abstract class LogReader
    {
        public string Filename { get; set; }
        public void Read()
        {
            ReadLogFile();
            ParsingData();
        }
        public abstract void ReadLogFile();
        public abstract void ParsingData();
    }
    class NetLogReader : LogReader
    {
        public override void ParsingData()
        {
            Console.WriteLine("Извлекаем сведения о сетевых соединениях.");
        }
        public override void ReadLogFile()
        {
            Console.WriteLine("Прочитан журнал сетевых соединений.");
        }
    }
    class SysLogReader : LogReader
    {
        public override void ParsingData()
        {
            Console.WriteLine("Извлекаем сведения о системных событиях.");
        }
        public override void ReadLogFile()
        {
            Console.WriteLine("Прочитан журнал системных событий.");
        }
    }
    class Client
    {
        void Execute()
        {
            NetLogReader net = new NetLogReader();
            SysLogReader sys = new SysLogReader();

            net.Read();
            sys.Read();
        }
    }
}
