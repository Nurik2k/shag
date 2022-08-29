using System;
using System.Collections.Generic;
using System.Text;

namespace ls4
{
    class UserService
    {
        public UserService()
        {
            Users = mew User[2];
            Users[0] = new User()
            {
                Name = "Nurzhan", SecondName = "Seisenbay", Birth = new DateTime(2004, 07, 15)
            };
        }
            
        public User[] Users { get; set; }
    }
}
