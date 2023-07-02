using OnlineShop.Saas.Monolithic.Models.DomainModels.PersonAggregates;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts.RepositoryFrameworks;

namespace OnlineShop.Saas.Monolithic.Models.Services.Contracts
{
    public interface IPersonRepository<TKey, TExist, TStatus> : IBaseRepository<Person?, TKey, TExist, TStatus> { }
}
