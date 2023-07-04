using Microsoft.AspNetCore.Mvc;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;
using OnlineShop.Saas.Monolithic.Models.Services.Repositories;

namespace OnlineShop.Saas.Monolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonRepository _personRepository;

        public PersonController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IActionResult> Index()
        {
            var persons =await _personRepository.SelectAllAsync();
            return View(persons);
        }
    }
}
