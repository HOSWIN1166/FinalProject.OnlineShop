using OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts.RepositoryFrameworks;

namespace OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts
{
    public interface IOrderDetailRepository<TKey, TExist, TStatus> : IBaseRepository<OrderDetail?, TKey, TExist, TStatus> { }
}
