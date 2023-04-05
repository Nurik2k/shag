using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Structural.Adapter
{
    abstract class Shape
    {
        public abstract string BoundingBox();
        public abstract string CreateManipulator();
    }
    class TextView
    {
        public string GetExtent()
        {
            return "Текст из TextView";
        }
    }
    class TextShape : Shape
    {
        private readonly string _text = " обработан в TextShape";
        public override string BoundingBox()
        {
            return new TextView() + _text;
        }
        public override string CreateManipulator()
        {
            return "Манипулятор в соответствии с интерфейсом";
        }
    }
}
