using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ef_core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Добавить блог
            // 2. Обновить контент блога
            // 3. Удалить
            // 4. Показать всё
            label:
            try
            {
                var number = ShowMenu();
                SwitchMenu(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                goto label;
            }
        }
        public static void SwitchMenu(int number)
        {
            switch (number)
            {
                case 1:
                    Console.Write("Имя автора: ");
                    var authorName = Console.ReadLine();
                    Console.Write("Контент блога: ");
                    var blogContent = Console.ReadLine();
                    AddNewBlog(authorName, blogContent);
                    break;
                case 2:
                    UpdateBlog();

                    break;
                case 3:
                    DeleteBlog();
                    break;
                case 4:
                    ShowAllData();
                    break;
                default:
                    break;
            }
        }

        private static void DeleteBlog()
        {
            //ShowAllData();
            Console.Write("Введите идентификатор для удаления блога: ");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Ты че?"));
            using var dbContext = new BloggingContext();
            var blog = dbContext.Blogs.First(f => f.Id == id);
            dbContext.Blogs.Remove(blog);
            dbContext.SaveChanges();
            Console.WriteLine("Блог удален!");
            Console.ReadLine();
            SwitchMenu(ShowMenu());
        }

        private static void UpdateBlog()
        {
            Console.Write("Введите идентификатор: ");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Ты че?"));
            using var dbContext = new BloggingContext();
            var blog = dbContext.Blogs.First(f => f.Id == id);
            Console.WriteLine("Измените контент: ");
            var newContent = Console.ReadLine();
            blog.Content = newContent;
            dbContext.SaveChanges();
            Console.WriteLine("Изменения успешно сохранены");
            Console.ReadLine();
            SwitchMenu(ShowMenu());
        }

        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Добавить блог");
            Console.WriteLine("2. Обновить контент блога");
            Console.WriteLine("3. Удалить");
            Console.WriteLine("4. Показать всё");

            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                return 0;
            }

            int number = int.Parse(inputString);
            return number;
        }

        public static void AddNewBlog(string authorName, string content)
        {
            var blog = new Blog()
            {
                AuthorName = authorName,
                Content = content,
                LikeCount = Random.Shared.Next(100, 100000),
                Url = "microsoft.com"
            };

            using var dbContext = new BloggingContext();

            dbContext.Blogs.Add(blog);
            dbContext.SaveChanges();
            Console.WriteLine("Изменения успешно сохранены.");
            Console.ReadLine();
            SwitchMenu(ShowMenu());
        }
        public static void ShowAllData()
        {
            using var dbContext = new BloggingContext();
            var blogs = dbContext.Blogs.ToList();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"{blog.AuthorName} - {blog.Content}, " +
                    $"Like count - {blog.LikeCount}");
            }
            Console.ReadLine();
            SwitchMenu(ShowMenu());
        }
    }
}