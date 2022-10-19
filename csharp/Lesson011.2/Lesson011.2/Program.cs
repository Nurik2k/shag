using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson011._2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<PC> pcs = new List<PC>();
            pcs.Add(new PC("Dell", "232321", 1000));
            pcs.Add(new PC("HP", "242321", 4000));
            using(FileStream fs = new FileStream("pc.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(PC[]));
                formatter.Serialize(fs, pcs.ToArray());

            }
        }
    }
}
