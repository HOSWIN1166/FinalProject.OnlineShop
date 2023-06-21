using Microsoft.AspNetCore.Mvc;
using OnlineShop.Saas.Monolithic.Controllers.Services;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;

namespace OnlineShop.Saas.Monolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personRepository;

        public PersonController(IPersonService personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IActionResult> Index()
        {
            var persons =await _personRepository.GetSelect();
            return View(persons);
        }
    }
}
