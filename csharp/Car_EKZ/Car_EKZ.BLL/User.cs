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
        public Project NameProject { get; set; }
        public User(string login, string password, string accessRights, Project nameProject)
        {
            Login = login;
            Password = password;
            AccessRights = accessRights;
            NameProject = nameProject;
        }
        private string Path { get; set; }
        public User(string Path)
        {
            this.Path = Path;
        }
    }
}
