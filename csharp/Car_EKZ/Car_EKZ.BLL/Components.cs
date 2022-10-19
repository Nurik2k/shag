using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public class Components
    {
        public string ComponentsName { get; set; }
        public int ComponentCode { get; set; }
        public Components(string componentsName, int componentCode)
        {
            ComponentsName = componentsName;
            ComponentCode = componentCode;
        }
    }
}
