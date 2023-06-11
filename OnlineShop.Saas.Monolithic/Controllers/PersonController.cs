using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Saas.Monolithic.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
