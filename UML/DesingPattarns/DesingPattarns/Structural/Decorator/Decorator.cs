using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Structural.Decorator
{
    abstract class VisualComponent
    {
        public abstract void Draw();
    }
    class TextView : VisualComponent
    {
        public override void Draw()
        {
            Console.WriteLine("Отображается TextView");
        }
    }
    class Decorator : VisualComponent
    {
        protected VisualComponent _component;
        public Decorator(VisualComponent component)
        {
            _component = component;
        }
        public override void Draw()
        {
            _component.Draw();
        }
    }
    class ScrollDecorator : Decorator
    {
        public ScrollDecorator(VisualComponent component) : base(component) {}
        public int ScrollPosition { get; set; }
        public new void Draw()
        {
            base._component.Draw();
            Console.WriteLine("Добавляется обработка ScrollDecorator");
        }
        public void ScrollTo()
        {
            Console.WriteLine("Изменяется значение ScrollPosition");
        }
    }
    class BorderDecorator : Decorator
    {
        public BorderDecorator(VisualComponent component) : base(component) { }
        public int BorderWidth { get; set; }
        public new void Draw()
        {
            base._component.Draw();
            Console.WriteLine("Добавляется обработка BorderDecorator");
        }
        public void DrawBorder()
        {
            Console.WriteLine("Изменяется значение BorderWidth");
        }
    }
    class Client
    {
        public void Execute()
        {
            TextView obj = new TextView();
            obj.Draw();

            ScrollDecorator scroll = new ScrollDecorator(new TextView());
            scroll.Draw();

            BorderDecorator border = new BorderDecorator(new TextView());
            border.Draw();
        }
    }
}
