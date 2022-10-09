using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edition
{
    public abstract class Edition
    {
        public virtual string Name { get; set; }
        public virtual string Autor { get; set; }
        public virtual int Year { get; set; }
        public virtual string EditorGroup { get; set; }
        public List<Edition> list;
        public Edition( string name, string autor)
        {
           
            Name = name;
            Autor = autor;
            list = new List<Edition>();
        }
    }
}
