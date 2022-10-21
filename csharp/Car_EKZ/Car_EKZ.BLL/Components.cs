using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
        public class Components
        {
        public string Path { get; set; }
        public Components()
        {

        }
        public Components(string path)
        {
            Path = path;
        }

        List<string> components = new List<string>();
            
            public void GetComponents()
            {
                
                foreach (var item in components)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            }
        }
}

