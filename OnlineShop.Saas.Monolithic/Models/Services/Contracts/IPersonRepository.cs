using OnlineShop.Saas.Monolithic.Models.DomainModels.PersonAggregates;

namespace OnlineShop.Saas.Monolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {

        Task<List<Person>> Select();
        //Person SelectById(Guid Id);
        //void Insert(Person person);
        //void Update(Person person);
        //void Delete(Guid Id);
    }
}
