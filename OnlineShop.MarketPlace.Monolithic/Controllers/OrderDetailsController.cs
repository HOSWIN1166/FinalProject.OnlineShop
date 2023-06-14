using Microsoft.AspNetCore.Mvc;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts;

namespace OnlineShop.MarketPlace.Monolithic.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailsController(IOrderDetailRepository orderDetailRepository )
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public  async Task<IActionResult> Index()
        {
            var orderDetail = await _orderDetailRepository.Select();
            return View(orderDetail);
        }
    }
}
