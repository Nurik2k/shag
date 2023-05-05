namespace DZAPI.models
{
    public interface IClientService
    {
        public IEnumerable<Product> Products();
        Product this[int Id] { get; set; }
        Product AddProduct(Product product);
        void DeleteProduct(int Id);
    }
}
