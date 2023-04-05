using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.Chain_of_Responsibility
{
    abstract class DataProcessing
    {
        protected DataProcessing _handler;
        public abstract void HandleRequest();
    }
    class Decoder : DataProcessing
    {
        public Decoder(DataProcessing handler)
        {
            base._handler = handler;
        }
        public override void HandleRequest()
        {
            bool decode = true;
            if (decode) // Если данные закодированы.
                Console.WriteLine("Декодирование данных");
            base._handler.HandleRequest();
        }
    }
    class Decompress : DataProcessing
    {
        public Decompress(DataProcessing handler)
        {
            base._handler = handler;
        }
        public override void HandleRequest()
        {
            bool decompres = true;
            if (decompres) // Если данные закодированы.
                Console.WriteLine("Распаковка данных");
            base._handler.HandleRequest();
        }
    }
    class Reformat : DataProcessing
    {
        public Reformat(DataProcessing handler)
        {
            base._handler = handler;
        }
        public override void HandleRequest()
        {
            bool reformat = true;
            if (reformat) // Если данные закодированы.
                Console.WriteLine("Изменение формата данных");
            base._handler.HandleRequest();
        }
    }
    class Saved : DataProcessing
    {
        public Saved(DataProcessing handler)
        {
            base._handler = handler;
        }
        public override void HandleRequest()
        {
            bool save = true;
            if (save) // Если данные закодированы.
                Console.WriteLine("Изменение формата данных");
            base._handler.HandleRequest();
        }
    }
    class Client
    {
        public void Execute()
        {
            Decoder obj = new Decoder(new Decompress(new Reformat(new Saved(null))));
            obj.HandleRequest();
        }
    }
}
