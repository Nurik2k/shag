using System.Runtime.CompilerServices;

namespace WebAppMVCLesson1.Admin.Models
{
    public interface IStorage
    {
        IEnumerable<Product> products { get; }
        Product this[string key] { get; set; }
        bool ContainsKey(string key);
        void RemoveItem(string key);
    }
    public class Storage :IStorage
    { 
        private Dictionary<string, Product> items = new Dictionary<string, Product>();
        public Product this[string key] 
        {
            get
            {
                return items[key];
            }
            set
            {
                items[key] = value;
            }
        }
        public IEnumerable<Product> products => items.Values;
        public bool ContainsKey(string key)
            => items.ContainsKey(key);   
        public void RemoveItem(string key)
            => items.Remove(key);
    }
}
