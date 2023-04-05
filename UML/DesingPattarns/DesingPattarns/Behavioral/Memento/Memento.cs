using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.Memento
{
    class MementoBots
    {
        public string State { get; private set; }
        public MementoBots(string state)
        {
            this.State = state;
        }
    }
    class Bots
    {
        public string State { get; set; }
        public void SetMemento(MementoBots memento)
        {
            State = memento.State;
        }
        public MementoBots CreateMemento()
        {
            return new MementoBots(State);
        }
    }
    class MementoHero
    {
        public string State { get; private set; }
        public MementoHero(string state)
        {
            this.State = state;
        }
    }
    class Hero
    {
        public string State { get; set; }
        public void SetMemento(MementoHero memento)
        {
            State = memento.State;
        }
        public MementoHero CreateMemento()
        {
            return new MementoHero(State);
        }
    }
    class Caretaker
    {
        public MementoHero MHero { get; set; }
        public MementoBots MBots { get; set; }
    }
}
