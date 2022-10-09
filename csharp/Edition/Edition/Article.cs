using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edition
{
    internal class Article
    {
        public string NameArticle { get; set; }
        public string NameAuthor { get; set; }
        public DateTime DatePublish { get; set; }
        public string PublishingHouse { get; set; }
        public Article(string nameArticle, string nameAuthor, DateTime datePublish, string publishingHouse)
        {
            NameArticle = nameArticle;
            NameAuthor = nameAuthor;
            DatePublish = datePublish;
            PublishingHouse = publishingHouse;
        }
        public string Print(Article ar)
        {
            return "Название статьи: " + ar.NameArticle +
                "\n Автор: " + ar.NameAuthor +
                "\n Дата публикации: " + ar.DatePublish +
                "\n Издание: " + ar.PublishingHouse;
        }
    }
}
