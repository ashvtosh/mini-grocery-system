using GroceryBackend.Models;
using GroceryBackend.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace GroceryBackend.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _repo.GetAllAsync());
        }
    }
}