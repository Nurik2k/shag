using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.Mediator
{
    abstract class DataSender
    {
        public abstract bool Send(string data);
    }
    abstract class SendMethod
    {
        public abstract bool Send(string data);
    }
    class SendInternet : DataSender
    {
        public override bool Send(string data)
        {
            Console.WriteLine("Данные отправлены через интернет");
            return true;
        }
    }
    class SendFile : DataSender
    {
        public override bool Send(string data)
        {
            Console.WriteLine("Данные записаны в файл для отправки");
            return true;
        }
    }
    class CheckNotSent
    {
        public bool Checked()
        {
            Console.WriteLine("Есть данные для отправки");
            return true;
        }
        public string GetData()
        {
            return "Сохраненные данные";
        }
    }
    class SenderMediator : DataSender
    {
        public override bool Send(string data)
        {
            CheckNotSent notSend = new CheckNotSent();
            SendInternet sendInternet = new SendInternet();
            SendFile sendFile = new SendFile();
            string oldData = null;
            if (notSend.Checked())
            {
                oldData = notSend.GetData();
            }
            data += oldData;
            if (!sendInternet.Send(data))
            {
                sendFile.Send(data);
            }
            return true;
        }
    }
}
