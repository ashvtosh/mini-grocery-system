using GroceryBackend.Models;

namespace GroceryBackend.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task UpdateProductAsync(Product product);
    }
}