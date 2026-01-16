using GroceryBackend.Models;

namespace GroceryBackend.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
    }
}