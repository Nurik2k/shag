using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Structural.Proxy
{
    abstract class Graphic
    {
        public abstract void Draw();
        public abstract void GetExtent();
        public abstract void Store();
        public abstract void Load();
    }
    class Image : Graphic
    {
        public override void Draw()
        {
            Console.WriteLine("Выполнена операция Draw");
        }

        public override void GetExtent()
        {
            Console.WriteLine("Выполнена операция GetExtent");
        }

        public override void Load()
        {
            Console.WriteLine("Выполнена операция Load");
        }

        public override void Store()
        {
            Console.WriteLine("Выполнена операция Store");
        }
    }
    class ImageProxy : Graphic
    {
        private Graphic _image;

        public override void Draw()
        {
            _image.Draw();
        }

        public override void GetExtent()
        {
            _image.GetExtent();
        }

        public override void Load()
        {
            _image.Load();
        }

        public override void Store()
        {
            _image.Store();
        }
    }
    class Client
    {
        public void Execute()
        {
            ImageProxy obj = new ImageProxy();
            obj.Draw();
            obj.GetExtent();
            obj.Load();
            obj.Store();
        }
    }
}
