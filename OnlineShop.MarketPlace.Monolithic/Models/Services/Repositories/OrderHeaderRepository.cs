using Microsoft.EntityFrameworkCore;
using OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Statuses;

namespace OnlineShop.MarketPlace.Monolithic.Models.Services.Repositories
{
    public class OrderHeaderRepository : IOrderHeaderRepository<Guid? , bool , RepositoryStatus>
    {
        private readonly OnlineShopDbContext _context;

        public OrderHeaderRepository(OnlineShopDbContext context)
        {
            _context = context;
        }


    }
}
