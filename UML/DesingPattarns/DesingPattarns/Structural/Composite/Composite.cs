using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Structural.Composite
{
    abstract class Graphic
    {
        public abstract void Draw();
        public abstract void Add(Graphic component);
        public abstract void Remove(Graphic component);
        public abstract Graphic GetChild(int element);
    }
    class Dot : Graphic
    {
        private int coordinate_x;
        private int coordinate_y;
        public Dot(int x, int y)
        {
            this.coordinate_x = x;
            this.coordinate_y = y;
        }
        public override void Draw()
        {
            Console.WriteLine("Отображена точка с координатами " + coordinate_x + " и " + coordinate_y);
        }
        public override void Add(Graphic component)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Graphic component)
        {
            throw new NotImplementedException();
        }
        public override Graphic GetChild(int element)
        {
            throw new NotImplementedException();
        }
    }
    class Line : Graphic
    {
        private int start_x;
        private int start_y;
        private int end_x;
        private int end_y;
        public Line(int s_x, int s_y, int e_x, int e_y)
        {
            start_x = s_x;
            start_y = s_y;
            end_x = e_x;
            end_y = e_y;
        }
        public override void Draw()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Отображена линия с координатами начало x=" + start_x + " и y=" + start_y);
            str.Append(" конец x=" + end_x + " и y=" + end_y);
            Console.WriteLine(str.ToString());
        }
        public override void Add(Graphic component)
        {
            throw new NotImplementedException();
        }
        public override Graphic GetChild(int element)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Graphic component)
        {
            throw new NotImplementedException();
        }
    }
    class Picture : Graphic
    {
        private List<Graphic> children;
        public override void Draw()
        {
            foreach (Graphic elem in children)
            {
                elem.Draw();
            }
        }
        public override void Add(Graphic component)
        {
            children.Add(component);
        }
        public override void Remove(Graphic component)
        {
            children.Remove(component);
        }
        public override Graphic GetChild(int element)
        {
            return children[element];
        }
    }
}
