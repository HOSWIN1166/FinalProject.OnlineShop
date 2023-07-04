using Microsoft.AspNetCore.Mvc;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Repositories;

namespace OnlineShop.MarketPlace.Monolithic.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly OrderDetailRepository _orderDetailRepository;

        public OrderDetailsController(OrderDetailRepository orderDetailRepository )
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public  async Task<IActionResult> Index()
        {
            var orderDetail = await _orderDetailRepository.SelectAllAsync();
            return View(orderDetail);
        }
    }
}
