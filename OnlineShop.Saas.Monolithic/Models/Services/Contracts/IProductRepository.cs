using OnlineShop.Saas.Monolithic.Models.DomainModels.ProductAggregates;

namespace OnlineShop.Saas.Monolithic.Models.Services.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> Select();
        //Person SelectById(Guid Id);
        //void Insert(Person person);
        //void Update(Person person);
        //void Delete(Guid Id);
    }
}
