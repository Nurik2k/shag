using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks9.BLL
{
    public class Book : Edition
    {
        public string BookName { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishYear { get; set; }

        public override void GetEditionInfo()
        {
            string info = string.Format("{0}, {1}, {2}", this.Title, this.PublishYear, this.Director);
        }
        
    }
}
