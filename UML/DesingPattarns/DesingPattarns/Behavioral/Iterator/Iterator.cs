using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Behavioral.Iterator
{
    abstract class Iterator
    {
        public abstract void First();
        public abstract void Next();
        public abstract bool IsDown();
        public abstract int CurrentItem();
    }
    abstract class AbstractList
    {
        public abstract Iterator CreateIterator();
        public abstract int Count();
        public abstract void Append(int item);
        public abstract void Remove(int item);
    }
    class SkipList : AbstractList
    {
        private List<int> _list = new List<int>();
        public List<int> AccessSkipList
        {
            get { return _list; }
        }
        public override void Append(int item)
        {
            _list.Add(item);
        }
        public override void Remove(int item)
        {
            _list.Remove(item);
        }
        public override int Count()
        {
            return _list.Count;
        }
        public override Iterator CreateIterator()
        {
            return new SkipListIterator(this);
        }
    }
    class SkipListIterator : Iterator
    {
        private SkipList _aggregate;
        int index;
        public SkipListIterator(SkipList obj)
        {
            _aggregate = obj;
            index = 0;
        }
        public override int CurrentItem()
        {
            return _aggregate.AccessSkipList[index];
        }
        public override void First()
        {
            index = 0;
        }
        public override bool IsDown()
        {
            if (index < _aggregate.AccessSkipList.Count)
                return false;
            else
                return true;
        }
        public override void Next()
        {
            index++;
        }
    }
}
