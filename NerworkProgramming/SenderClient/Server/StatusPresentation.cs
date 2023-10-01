using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class StatusPresentation
    {
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public string Status { get; set; }

        public string Resource { get; set; }

        public override string ToString()
        {
            return string.Format("{0:HH:mm:ss} - {1}, {2}", TimeStamp, Status, Resource);
        }
    }
}
