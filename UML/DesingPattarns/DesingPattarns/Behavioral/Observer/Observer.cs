using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.Observer
{
    class Client
    {
        static void Execute()
        {
            Stock stock = new Stock();
            Bank bank = new Bank("ЮнитБанк", stock);
            Broker broker = new Broker("Иван Иваныч", stock);
            // имитация торгов
            stock.Market();
            // брокер прекращает наблюдать за торгами
            broker.StopTrade();
            // имитация торгов
            stock.Market();

            Console.Read();
        }
    }

    abstract class Observer
    {
        public abstract void Update(Object ob);
    }

    abstract class Observable
    {
        public abstract void RegisterObserver(Observer o);
        public abstract void RemoveObserver(Observer o);
        public abstract void NotifyObservers();
    }

    class Stock : Observable
    {
        StockInfo sInfo; // информация о торгах

        List<Observer> observers;
        public Stock()
        {
            observers = new List<Observer>();
            sInfo = new StockInfo();
        }
        public override void RegisterObserver(Observer o)
        {
            observers.Add(o);
        }

        public override void RemoveObserver(Observer o)
        {
            observers.Remove(o);
        }

        public override void NotifyObservers()
        {
            foreach (Observer o in observers)
            {
                o.Update(sInfo);
            }
        }

        public void Market()
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }

    class StockInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }

    class Broker : Observer
    {
        public string Name { get; set; }
        Observable stock;
        public Broker(string name, Observable obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }
        public override void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }
        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Bank : Observer
    {
        public string Name { get; set; }
        Observable stock;
        public Bank(string name, Observable obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }
        public override void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
        }
    }
}
