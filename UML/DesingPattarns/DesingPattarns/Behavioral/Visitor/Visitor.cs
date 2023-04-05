using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.Visitor
{
    abstract class Pet
    {
        public string Name { get; set; }
        public Pet(string name)
        {
            Name = name;
        }
        public abstract void Accept(PetVisitor v);
    }
    class Cat : Pet
    {
        public Cat(string name) : base(name) { }
        public override void Accept(PetVisitor v)
        {
            v.Visit(this);
        }
    }
    class Dog : Pet
    {
        public Dog(string name) : base(name) { }
        public override void Accept(PetVisitor v)
        {
            v.Visit(this);
        }
    }
    abstract class PetVisitor
    {
        public abstract void Visit(Cat cat);
        public abstract void Visit(Dog dog);
    }
    class FeedingVisitor : PetVisitor
    {
        public override void Visit(Cat cat)
        {
            Console.WriteLine("Покормить тунцом " + cat.Name);
        }

        public override void Visit(Dog dog)
        {
            Console.WriteLine("Покормить стейком " + dog.Name);
        }
    }
    class PlayingVisitor : PetVisitor
    {
        public override void Visit(Cat cat)
        {
            Console.WriteLine("Поиграть в перышко с " + cat.Name);
        }

        public override void Visit(Dog dog)
        {
            Console.WriteLine("Поиграть в брось-принеси с " + dog.Name);
        }
    }
    class Client
    {
        public void Excute()
        {
            FeedingVisitor fv = new FeedingVisitor();
            fv.Visit(new Cat("Персик"));
            fv.Visit(new Dog("Тузик"));

            PlayingVisitor pv = new PlayingVisitor();
            pv.Visit(new Dog("Шарик"));
            pv.Visit(new Cat("Пушок"));
        }
    }
}
