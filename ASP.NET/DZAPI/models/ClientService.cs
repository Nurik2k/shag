namespace DZAPI.models
{
    public class ClientService : IClientService
    {
        private Dictionary<int, Product> items;
        public ClientService()
        {
            items = new Dictionary<int, Product>();
            new List<Product>()
            {
                new Product() { Id = 1, Name = "Banana", Address = "Mametova 13", Price = 200},
                new Product() { Id = 2, Name = "Potato", Address = "Kalmakova 107", Price=60},
                new Product() { Id = 3, Name = "UPS", Address = "Nazarbaeva 200", Price = 380}
            }.ForEach(p => AddProduct(p));
        }
        public Product this[int Id] => items.ContainsKey(Id) ? items[Id] : null;

        Product IClientService.this[int Id] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<Product> Products() => items.Values;
        public Product AddProduct(Product product)
        {
            if(product == null)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; }
                product.Id = key;
            }
            items[product.Id] = product;
            return product;
        }
        public void DeleteProduct(int Id) => items.Remove(Id);  
    }
}
