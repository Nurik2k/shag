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
            public int ComponentID { get; set; }


            public Component()
            {

            }
            public Component(string componentsName, int componentID)
            {
            ComponentsName = componentsName;
            ComponentID = componentID;
            }
          
            public override string ToString()
            {
                return string.Format("{0} | {1}\n",ComponentID, ComponentsName);

            }

        }
}

