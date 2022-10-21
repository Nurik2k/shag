using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
        public class Component
        {
            public string ComponentsName { get; set; }

            public Component()
            {

            }
            public Component(string componentsName)
            {
            ComponentsName = componentsName;
            }
          
            public override string ToString()
            {
                return string.Format("{0}\n", ComponentsName);

            }

        }
}

