using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edition
{
    public class Book 
    {
        public string NameBook { get; set; }
        public string NameAuthor { get; set; }
        public DateTime DatePublish { get; set; }
        public string PublishingHouse { get; set; }
        public Book(string nameBook, string nameAuthor, DateTime datePublish, string publishingHouse)
        {
            NameBook = nameBook;
            NameAuthor = nameAuthor;
            DatePublish = datePublish;
            PublishingHouse = publishingHouse;
        }
        public string Print(Book bk)
        {
            return "Название книги: " + bk.NameBook +
                "\n Автор: " + bk.NameAuthor +
                "\n Дата публикации: " + bk.DatePublish +
                "\n Издание: " + bk.PublishingHouse;
        }
    }
}
