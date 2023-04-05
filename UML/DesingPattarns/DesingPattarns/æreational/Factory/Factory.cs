using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Сreational.Factory
{
    abstract class SenderProduct
    {
        protected string _data;
        public abstract void Send();
    }
    class WebSender : SenderProduct
    {
        public string Recipient { get; set; }
        public WebSender(string data)
        {
            base._data = data;
        }
        public override void Send()
        {
            Console.WriteLine("<" + this.Recipient + " data sent <" + base._data + "> to WEB");
        }
    }
    class BluetoothSender : SenderProduct
    {
        public string Recipient { get; set; }
        public BluetoothSender(string data)
        {
            base._data = data;
        }
        public override void Send()
        {
            Console.WriteLine("<" + this.Recipient + " data sent <" + base._data + "> to Bluetooth");
        }
    }
    abstract class SendDataCreator
    {
        protected SenderProduct _product;
        public abstract void Send();
    }
    class SendData : SendDataCreator
    {
        public SendData(SenderProduct product)
        {
            base._product = product;
        }
        public override void Send()
        {
            base._product.Send();
        }
    }
}
