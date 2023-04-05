using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Structural.Flyweight
{
    abstract class Gliph
    {
        public abstract void Draw(Gliph context);
        public abstract Gliph Intersects(int point, Gliph context);
    }
    class Row : Gliph
    {
        private List<Gliph> _rows;
        public override void Draw(Gliph context)
        {
            _rows.Add(context);
            Console.WriteLine("Отобразить строку context");
        }

        public override Gliph Intersects(int point, Gliph context)
        {
            _rows.Insert(point, context);
            return _rows[point];
        }
    }
    class Column : Gliph
    {
        private List<Gliph> _сolumns;
        public override void Draw(Gliph context)
        {
            _сolumns.Add(context);
            Console.WriteLine("Отобразить колонку context");
        }

        public override Gliph Intersects(int point, Gliph context)
        {
            _сolumns.Insert(point, context);
            return _сolumns[point];
        }
    }
    class Character : Gliph
    {
        private char _chr;
        public Character(char chr)
        {
            _chr = chr;
        }
        public override void Draw(Gliph context)
        {
            Console.WriteLine("Отобразить символ " + _chr);
        }

        public override Gliph Intersects(int point, Gliph context)
        {
            throw new NotImplementedException();
        }
    }
    class Client
    {
        public void Execute()
        {
            Row row = new Row();
            row.Draw(new Character('F'));
            row.Draw(new Character('I'));
            row.Draw(new Character('R'));
            row.Draw(new Character('S'));
            row.Draw(new Character('T'));

            Row row1 = new Row();
            row1.Draw(new Character('S'));
            row1.Draw(new Character('E'));
            row1.Draw(new Character('C'));
            row1.Draw(new Character('O'));
            row1.Draw(new Character('N'));
            row1.Draw(new Character('D'));

            Column column = new Column();
            column.Draw(row);
            column.Draw(row1);
        }
    }
}
