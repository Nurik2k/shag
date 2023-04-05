using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Сreational.Prototype
{
    abstract class Graphic
    {
        public abstract void Draw(int position);
        public abstract Graphic Clone();
    }
    class Staff : Graphic
    {
        public override void Draw(int position)
        {
            Console.WriteLine("Staff Установлено в позицию: " + position);
        }
        public override Graphic Clone()
        {
            return new Staff();
        }
    }
    abstract class MusicalNote : Graphic
    {
        public override abstract Graphic Clone();
    }
    class WholeNote : MusicalNote
    {
        public override void Draw(int position)
        {
            Console.WriteLine("WholeNote Установлено в позицию: " + position);
        }
        public override Graphic Clone()
        {
            return new WholeNote();
        }
    }
    class HalfNote : MusicalNote
    {
        public override void Draw(int position)
        {
            Console.WriteLine("HalfNote Установлено в позицию: " + position);
        }
        public override Graphic Clone()
        {
            return new HalfNote();
        }
    }
    class GraphicTool
    {
        private Graphic _prototype;
        public GraphicTool(Graphic obj)
        {
            _prototype = obj;
        }
        public void Manipulate()
        {
            Graphic p = _prototype.Clone();
            p.Draw(100);
        }
    }
}
