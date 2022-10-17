using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson011
{
    [Serializable]
    public class User {
    public int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        [NonSerialized]
        public int IIN;
        public User()
        {

        }
        public User(int userId, string fullName, DateTime dob)
        {
            UserId = userId;
            FullName = fullName;
            Dob = dob;
        }
        public override string ToString()
        {
            return String.Format("ID: {0};\n FullName: {1}", UserId, FullName);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Exmpl_4("Книга1.csv");

        }
        public static void Exmpl_4(string path)
        {
            List<Usercv> users = new List<Usercv>();
            using (StreamReader sr = new StreamReader(path))
            {
                
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(';');
                    Usercv user = new Usercv(words[0], words[1], Convert.ToInt32(words[2]), Convert.ToInt32(words[3]));
                    users.Add(user);
                }
            }
            using(FileStream fs = new FileStream("phone_bok.soap", FileMode.OpenOrCreate))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(fs, users.ToArray());
            }
        }

        public static void Exmpl_3(User user)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(User));
            using (FileStream fs = new FileStream("user.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, user);
                Console.WriteLine("файл создан");
            }
            using (FileStream fs = new FileStream("user.xml", FileMode.Open))
            {
                User newUser = (User)formatter.Deserialize(fs);
                Console.WriteLine(newUser);
            }
        }

        public static void Exmpl_2(User user)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream("user.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, user);
                Console.WriteLine("файл создан");
            }
            using (FileStream fs = new FileStream("user.soap", FileMode.Open))
            {
                User newUser = (User)formatter.Deserialize(fs);
                Console.WriteLine(newUser);
            }

        }

        public static void Exmpl_1(User user)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, user);
                Console.WriteLine("файл создан");
            }
            using (FileStream fs = new FileStream("user.dat", FileMode.Open))
            {
                User newUser = (User)formatter.Deserialize(fs);
                Console.WriteLine(newUser);
            }
        }
    }
}
