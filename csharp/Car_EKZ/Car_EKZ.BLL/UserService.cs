
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_EKZ.BLL
{
    public class UserService
    {
       public string Path { get; set; }
        public UserService(){}
        public UserService(string Path){this.Path = Path;}
        
        public ReturnResult CreateUser(User user)
        {
            ReturnResult result = new ReturnResult();
            using (var db = new LiteDatabase(Path))
            {
                var users = db.GetCollection<User>(typeof(User).Name);
                users.Insert(user);
            }
            return result;

        }
        public List<User> GetUsers() { 
        List<User> ListUsers = new List<User>();
            using (var db = new LiteDatabase(Path))
            {
                var users = db.GetCollection<User>(typeof(User).Name);
                ListUsers = users.FindAll().ToList();
            }
            return ListUsers;
        }
        public string PrintUsers(List<User> ListUsers)
        {
            string result = "";
            foreach (var item in ListUsers)
            {
                result += item.ToString();
            }
            return result;
        }


    }
}