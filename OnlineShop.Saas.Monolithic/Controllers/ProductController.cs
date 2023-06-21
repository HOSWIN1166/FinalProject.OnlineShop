using Microsoft.AspNetCore.Mvc;
using OnlineShop.Saas.Monolithic.Controllers.Services;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;

namespace OnlineShop.Saas.Monolithic.Controllers
{
    public class ProductController : Controller
    {
        private readonly IPersonService _productRepository;

        public ProductController(IPersonService productRepository)
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
