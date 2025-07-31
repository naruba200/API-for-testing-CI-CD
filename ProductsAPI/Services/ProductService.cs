using ProductsAPI.Models;
namespace ProductsAPI.Services
{
    public class ProductService
    {
        private static List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99M },
            new Product { Id = 2, Name = "Mouse", Price = 19.99M }
        };

        public List<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
        public void Add(Product product) => _products.Add(product);
        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1) _products[index] = product;
        }
        public void Delete(int id) => _products.RemoveAll(p => p.Id == id);
    }
}
