using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.Strategy
{
    abstract class Compositor
    {
        public abstract void Compose();
    }
    class SimpleCompositor : Compositor
    {
        public override void Compose()
        {
            Console.WriteLine("Составление строки SimpleCompositor");
        }
    }
    class ArrayCompositor : Compositor
    {
        public override void Compose()
        {
            Console.WriteLine("Составление строки ArrayCompositor");
        }
    }
    class TeXCompositor : Compositor
    {
        public override void Compose()
        {
            Console.WriteLine("Составление строки TeXCompositor");
        }
    }
    class Composition
    {
        Compositor compositor;
        public Composition(Compositor c)
        {
            compositor = c;
        }
        public void Traverse()
        {

        }
        public void Repair()
        {
            compositor.Compose();
        }
    }
    class Client
    {
        public void Execute()
        {
            Composition comp = new Composition(new SimpleCompositor());
            comp.Repair();
        }
    }
}
