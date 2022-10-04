using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {

        public delegate void GetMessage();
        public void ShowMessage(GetMessage _del)
        {
            GetMessage del = _del;
            del.Invoke();//Вызов метода!
        }
       
    }
}
