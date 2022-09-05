﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBB.Online.BLL
{
    public class UserService
    {
        public UserService(string Path)
        {
            this.Path = Path;
        }

        private string Path { get; set; }
        public List<User> Users { get; set; }


        public bool Registration(User user, out string message)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var users = db.GetCollection<User>("Users");

                    if (GetUser(user.IIN) != null)
                    {
                        message = "Пользователь с ИИН: " + user.IIN + " уже зарегистрирован!";
                        return false;
                    }
                    else
                    {
                        users.Insert(user);
                    }
                }

                message = "Successfully";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public User GetUser(string iin)
        {
            User user = null;
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var users = db.GetCollection<User>("Users");
                    user = users.FindOne(f => f.IIN == iin);
                }
            }
            catch
            {
                user = null;
            }

            return user;
        }
    }
}
