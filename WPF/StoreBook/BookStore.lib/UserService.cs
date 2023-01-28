using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.lib
{
    public class UserService
    {
        public EntityModel db = new EntityModel();

        public List<City> GetCities()
        {
            return db.Cities.ToList();
        }
        public bool Register(Users user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception) { return false; }
        }
        
    }
}
