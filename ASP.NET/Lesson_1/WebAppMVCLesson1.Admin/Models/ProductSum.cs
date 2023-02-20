using Microsoft.AspNetCore.DataProtection.Repositories;
using System.Security.Cryptography.X509Certificates;

namespace WebAppMVCLesson1.Admin.Models
{
    public class ProductSum
    {
        public IRepository Repository { get; set; }
        public ProductSum(IRepository repo)
        {
            Repository = repo;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        Product this[string name] { get; }
        void AddProduct(Product product);
        void DeleteProduct(Product product);
    }
    public class Repository : IRepository
    {
        private Dictionary<string, Product> _products;
        public Repository()
        {
            _products= new Dictionary<string, Product>();
            new List<Product>
            {
                new Product{Name = "Women Shoes", Price= 99M},
                new Product{Name = "Skirts", Price= 29.99M},
            }.ForEach(p=>AddProduct(p));
        }
        public IEnumerable<Product> Products => _products.Values;
        public Product this[string name] => _products[name];
        public void AddProduct(Product product)
        {
            _products.Add(product.Name, product);
        }
        public void DeleteProduct(Product product)
        {
            _products.Remove(product.Name);
        }
    }
}