using OnlineShop.Saas.Monolithic.Models.DomainModels.ProductAggregates;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts.RepositoryFrameworks;

namespace OnlineShop.Saas.Monolithic.Models.Services.Contracts
{
    public interface IProductRepository<TKey, TExist, TStatus> : IBaseRepository<Product?, TKey, TExist, TStatus> { }
}
