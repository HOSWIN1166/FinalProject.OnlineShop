using OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates;

namespace OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts
{
    public interface IOrderHeaderRepository
    {
        Task<List<OrderHeader>> Select();
        //Person SelectById(Guid Id);
        //void Insert(Person person);
        //void Update(Person person);
        //void Delete(Guid Id);
    }
}
