using Microsoft.AspNetCore.Mvc;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;

namespace OnlineShop.Saas.Monolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IActionResult> Index()
        {
            var persons =await _personRepository.Select();
            return View(persons);
        }
    }
}
