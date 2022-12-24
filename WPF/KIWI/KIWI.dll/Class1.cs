using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIWI.dll
{
    public class Class1
    {
        EntityModel db = new EntityModel();
        public bool CheckUser(string login , string password)
        {
            return db.AccoutServices.Any(w => w.Login == login & w.Password == password);
        }
    }
}
