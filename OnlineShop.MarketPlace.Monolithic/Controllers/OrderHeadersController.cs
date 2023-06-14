using Microsoft.AspNetCore.Mvc;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts;

namespace OnlineShop.MarketPlace.Monolithic.Controllers
{
    public class OrderHeadersController : Controller
    {
        private readonly IOrderHeaderRepository _orderHeaderRepository;

        public OrderHeadersController(IOrderHeaderRepository orderHeaderRepository)
        {
            _orderHeaderRepository = orderHeaderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var orderHeader = await _orderHeaderRepository.Select();
            return View(orderHeader);
        }
    }
}
