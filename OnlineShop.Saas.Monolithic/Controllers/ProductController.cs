using Microsoft.AspNetCore.Mvc;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;

namespace OnlineShop.Saas.Monolithic.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.Select();
            return View(products);
        }
    }
}
