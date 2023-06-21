using OnlineShop.Saas.Monolithic.Controllers.Dtos;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;

namespace OnlineShop.Saas.Monolithic.Controllers.Services
{
    public interface IPersonService : IPersonRepository
    {
        Task<List<PersonGetDto>> GetSelect();
    }
}
