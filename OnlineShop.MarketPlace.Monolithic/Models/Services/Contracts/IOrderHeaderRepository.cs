using OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts.RepositoryFrameworks;

namespace OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts
{
    public interface IOrderHeaderRepository<TKey, TExist, TStatus> : IBaseRepository<OrderHeader?, TKey, TExist, TStatus> { }
}
