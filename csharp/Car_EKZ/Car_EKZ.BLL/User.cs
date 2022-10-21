using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string AccessRights { get; set; }
        public User(string login, string password, string accessRights)
        {
            Login = login;
            Password = password;
            AccessRights = accessRights;
        }
        private string Path { get; set; }
        public User(string Path)
        {
            this.Path = Path;
        }
        public User() { }
        public override string ToString()
        {
            return String.Format("{0} {1}", Login, AccessRights);
        }
    }
}
