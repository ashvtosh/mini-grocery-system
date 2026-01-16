using GroceryBackend.Models;

namespace GroceryBackend.Services
{
    public interface IOrderService
    {
        Task<string> PlaceOrderAsync(OrderRequest request);
    }
}