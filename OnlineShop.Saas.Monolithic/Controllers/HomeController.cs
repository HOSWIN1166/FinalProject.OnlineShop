using Microsoft.AspNetCore.Mvc;
using OnlineShop.Saas.Monolithic.Controllers.Dtos;
using OnlineShop.Saas.Monolithic.Models;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;
using OnlineShop.Saas.Monolithic.Models.Services.Statuses;
using System.Diagnostics;

namespace OnlineShop.Saas.Monolithic.Controllers
{
    public class HomeController : Controller
    {

        private readonly IProductRepository<Guid?, bool, RepositoryStatus> _productRepository;

        public HomeController(IProductRepository<Guid?, bool, RepositoryStatus> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            await _productRepository.DeleteByIdAsync(new Guid("577b7270-0095-4a47-8a3a-825e740e4eb0"));
            var (Products, status) = await _productRepository.SelectAllAsync();
            List<GetProductDto> getProductDtos = new List<GetProductDto>();
            foreach (var item in Products)
            {
                getProductDtos.Add(new GetProductDto() { Id = item.Id, Title = item.Title, UnitPrice = item.UnitPrice });
            }
            return View(getProductDtos);
        }
    }
}
