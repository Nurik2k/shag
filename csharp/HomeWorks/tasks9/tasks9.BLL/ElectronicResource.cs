using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace tasks9.BLL
{
    internal class ElectronicResource : Edition
    {
        public string ThirtTitle { get; set; }
        public string AuthorThirtName { get; set; }
        public string Link { get; set; }
        public string Annotation { get; set; }
        public override void GetEditionInfo()
        {
            Console.WriteLine(ThirtTitle);
            Console.WriteLine(AuthorThirtName);
            Console.WriteLine(Link);
            Console.WriteLine(Annotation);
        }
        public ElectronicResource(string thirtTitle, string authorThirtName, string link, string annotation)
        {
            ThirtTitle = thirtTitle;
            AuthorThirtName = authorThirtName;
            Link = link;
            Annotation = annotation;
        }
    }
}
