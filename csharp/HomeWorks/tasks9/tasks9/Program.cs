using tasks9.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EditionService editionService = new EditionService();
            editionService[1].GetEditionInfo();
        }
    }
}
