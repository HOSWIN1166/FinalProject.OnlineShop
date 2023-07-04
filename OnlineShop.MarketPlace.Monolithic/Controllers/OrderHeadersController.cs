using Microsoft.AspNetCore.Mvc;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Repositories;

namespace OnlineShop.MarketPlace.Monolithic.Controllers
{
    public class OrderHeadersController : Controller
    {
        private readonly OrderHeaderRepository _orderHeaderRepository;

        public OrderHeadersController(OrderHeaderRepository orderHeaderRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var orderHeader = await _orderHeaderRepository.SelectAllAsync();
            return View(orderHeader);
        }
    }
}
