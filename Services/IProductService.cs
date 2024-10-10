using dan_storbaek_server.Domains;

namespace dan_storbaek_server.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(string id);
        Task<Product?> CreateAsync(Product newProduct);
        Task<Product?> UpdateAsync(string id, Product updatedProduct);
        Task<bool> RemoveAsync(string id);
    }
}
