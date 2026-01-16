using GroceryBackend.Data;
using GroceryBackend.Models;
using GroceryBackend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GroceryBackend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly AppDbContext _context;

        public OrderService(IProductRepository productRepo, IOrderRepository orderRepo, AppDbContext context)
        {
            _productRepo = productRepo;
            _orderRepo = orderRepo;
            _context = context;
        }

        public async Task<string> PlaceOrderAsync(OrderRequest request)
        {
            // TRANSACTION LOGIC START
            using var transaction = await _context.Database.BeginTransactionAsync();
            
            try
            {
                // 1. Check if product exists
                var product = await _productRepo.GetByIdAsync(request.ProductId);
                if (product == null) throw new Exception("Product not found");

                // 2. Check stock availability
                if (product.Stock < request.Quantity) throw new Exception("Insufficient stock");

                // 3. Reduce product stock
                product.Stock -= request.Quantity;
                await _productRepo.UpdateProductAsync(product);

                // 4. Create order record
                var order = new Order
                {
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    TotalPrice = product.Price * request.Quantity,
                    CreatedAt = DateTime.UtcNow
                };
                await _orderRepo.AddOrderAsync(order);

                // 5. Commit Transaction
                await transaction.CommitAsync();
                return "Order placed successfully";
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}