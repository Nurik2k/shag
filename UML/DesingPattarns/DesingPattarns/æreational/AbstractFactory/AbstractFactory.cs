using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Сreational.AbstractFactory
{
    // Абстрактный класс Абстрактной фабрики определяет общее поведение для извлечения данных
    abstract class AbstractFactory
    {
        protected string _url;
        protected string _login;
        protected string _password;
        protected AbstractFactory()
        {
            this._url = "Подключение к хосту ";
            this._login = "Введен логин: login";
            this._password = "Введен пароль: password";
        }
        public abstract bool Open();
        public abstract void Read();
        public abstract void Close();
        public abstract void GetPost();
    }
    // Абстрактный класс Абстрастного продукта для работы с Facebook.
    abstract class FacebookAbstractProduct
    {
        public string Date { get; set; }
        public string Text { get; set; }
    }
    // Абстрактный класс Абстрастного продукта для работы с Twitter.
    abstract class TwitterAbstractProduct
    {
        public string Date { get; set; }
        public string Text { get; set; }
    }
    // Реализация класса Продукта для Facebook.
    class FacebookPostProduct : FacebookAbstractProduct
    {
        // Атрибуты
        public byte[] Picture { get; }
        public int Like { get; }
        // Конструктор с параметрами
        public FacebookPostProduct(string date, string text)
        {
            base.Date = date;
            base.Text = text;
        }
    }
    // Реализация класса Продукта для Facebook.
    class FacebookFriendPostProduct : FacebookAbstractProduct
    {
        // Атрибуты
        public string Friend { get; }
        // Конструктор с параметрами
        public FacebookFriendPostProduct(string friend, string date, string text)
        {
            this.Friend = friend;
            base.Date = date;
            base.Text = text;
        }
    }
    // Реализация класса Продукта для Twitter.
    class TwitterPostProduct : TwitterAbstractProduct
    {
        // Атрибуты
        public byte[] Picture { get; }
        public int Repost { get; }
        public TwitterPostProduct(string date, string text)
        {
            base.Date = date;
            base.Text = text;
        }
    }
    class FacebookFactory : AbstractFactory
    {
        // Атрибуты
        private FacebookPostProduct[] _posts;
        private FacebookFriendPostProduct[] _friends;

        public override bool Open()
        {
            return true;
        }
        public override void Read()
        {
            _posts = new FacebookPostProduct[3];
            _posts[0] = new FacebookPostProduct("01.01.2020", "С новым годом!");
            _posts[1] = new FacebookPostProduct("11.01.2020", "У меня все отлично!");
            _posts[2] = new FacebookPostProduct("07.02.2020", "Наступили грустные дни.");

            ReadFriendsPost();
        }
        public override void Close()
        {
            return;
        }
        protected string[] ReadFriends()
        {
            string[] answer = new string[3];
            answer[0] = "Маша Иванова";
            answer[1] = "Иван Семенов";
            answer[2] = "Андрей Чижов";
            return answer;
        }
        private void ReadFriendsPost()
        {
            string[] myFriends = ReadFriends();
            _friends = new FacebookFriendPostProduct[3];
            for (int i = 0; i < 3; i++)
            {
                _friends[i] = new FacebookFriendPostProduct(myFriends[i], "01.01.2020", "Всех с новым годом!");
            }
        }
        public override void GetPost()
        {
            foreach (FacebookAbstractProduct element in _posts)
            {
                Console.WriteLine(element.Text);
            }
            foreach (FacebookAbstractProduct element in _friends)
            {
                Console.WriteLine(element.Text);
            }
        }
    }

    class TwitterFactory : AbstractFactory
    {
        private TwitterPostProduct[] _posts;

        public override bool Open()
        {
            return true;
        }
        public override void Read()
        {
            _posts = new TwitterPostProduct[3];
            _posts[0] = new TwitterPostProduct("01.01.2020", "С новым годом!");
            _posts[1] = new TwitterPostProduct("11.01.2020", "У меня все отлично!");
            _posts[2] = new TwitterPostProduct("07.02.2020", "Наступили грустные дни.");
        }
        public override void Close()
        {
            return;
        }
        public override void GetPost()
        {
            foreach(TwitterPostProduct element in _posts)
            {
                Console.WriteLine(element.Text);
            }
        }
    }

    class Client
    {
        public void GetPosts()
        {
            AbstractFactory facebook = new FacebookFactory();
            AbstractFactory twitter = new TwitterFactory();
            if (facebook.Open() && twitter.Open())
            {
                facebook.Read();
                facebook.GetPost();

                twitter.Read();
                twitter.GetPost();
            }
        }
    }
}
