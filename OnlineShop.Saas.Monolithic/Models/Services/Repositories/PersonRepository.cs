using Microsoft.EntityFrameworkCore;
using OnlineShop.Saas.Monolithic.Models.DomainModels.PersonAggregates;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;

namespace OnlineShop.Saas.Monolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly OnlineShopDbContext _context;

        public PersonRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> Select()
        {
            using (_context)
            {
                try
                {

                    var persons = await _context.Person.ToListAsync();
                    return persons;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.Person != null) _context.Dispose();
                }
            }
        }
    }
}
