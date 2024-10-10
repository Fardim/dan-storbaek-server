using dan_storbaek_server.Domains;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace dan_storbaek_server.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productsCollection;
        public ProductService(IOptions<DanTestDatabaseSettings> danTestDatabaseSettings)
        {
            var mongoClient = new MongoClient(danTestDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(danTestDatabaseSettings.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<Product>(danTestDatabaseSettings.Value.ProductsCollectionName);
        }
        public async Task<Product?> CreateAsync(Product newProduct)
        {
            await _productsCollection.InsertOneAsync(newProduct);
            return await GetProductById(newProduct.Id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productsCollection.Find(d => true).ToListAsync();
        }

        public async Task<Product?> GetProductById(string id)
        {
            return await _productsCollection.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveAsync(string id)
        {
            await _productsCollection.DeleteOneAsync(x => x.Id == id);
            return true;
        }

        public async Task<Product?> UpdateAsync(string id, Product updatedProduct)
        {
            await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);
            return await GetProductById(id);
        }
    }
}
