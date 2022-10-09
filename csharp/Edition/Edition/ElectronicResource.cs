using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edition
{
    public class ElectronicResource
    {
        public string NameElectronicResource { get; set; }
        public string NameAuthor { get; set; }
        public string Link { get; set; }
        public string Annotation { get; set; }
        public ElectronicResource(string NameElectronicResource, string NameAuthor, string Link, string Annotation)
        {
            this.NameElectronicResource = NameElectronicResource;
            this.NameAuthor = NameAuthor;
            this.Link = Link;
            this.Annotation =  Annotation;
        }
        public string Print(ElectronicResource er)
        {
            return "Название электронного ресурса: " + er.NameElectronicResource +
                "\n Автор: " + er.NameAuthor + 
                "\n Ссылка: " + er.Link + 
                "\n Аннотация: " + er.Annotation;
        }


    }
}
