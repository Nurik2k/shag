using Db_First.Data;
using Microsoft.EntityFrameworkCore;

namespace Db_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var DbContext = new ShopDbContext();
            try
            {
                Console.Write("Input Login: ");
                var login = "sidorenkoegor";
                var user = DbContext.Users
                    .Include(d => d.Baskets)
                    .ThenInclude(d => d.BasketProducts)
                    .ThenInclude(p => p.Product)
                    .Where(w => w.Baskets.Any(a => a.BasketProducts.Any()))
                    .First(f => f.Login == login);
                Console.WriteLine($"User with login - {user.Login} has following baskets:");
                foreach (var userBasket in user.Baskets)
                {
                    
                    foreach (var basket in userBasket.BasketProducts)
                    {
                        Console.WriteLine($"User {userBasket.User.Name} has - {userBasketProduct.Product.Name}");

                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}