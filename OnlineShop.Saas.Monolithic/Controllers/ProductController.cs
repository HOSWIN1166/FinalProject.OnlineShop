using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Saas.Monolithic.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
