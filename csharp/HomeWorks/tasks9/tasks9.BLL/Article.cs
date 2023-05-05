using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks9.BLL
{
    internal class Article:Edition
    {
        public string SecTitle { get; set; }
        public string AuthorSecindName { get; set; }
        public string TitleJournal { get; set; }
        public int Number { get; set; }
        public DateTime YersOfSecPublic { get; set; }
        public override void GetEditionInfo()
        {
            Console.WriteLine(SecTitle);
            Console.WriteLine(AuthorSecindName);
            Console.WriteLine(TitleJournal);
            Console.WriteLine(Number);
            Console.WriteLine(YersOfSecPublic);
            
        }
        public Article( string st, string asn)
        {
            SecTitle = st;
            AuthorSecindName = asn;
        }
    }
}
