using Microsoft.EntityFrameworkCore;
using OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts;

namespace OnlineShop.MarketPlace.Monolithic.Models.Services.Repositories
{
    public class OrderHeaderRepository : IOrderHeaderRepository
    {
        private readonly OnlineShopDbContext _context;

        public OrderHeaderRepository(OnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderHeader>> Select()
        {
            using (_context)
            {
                try
                {
                    var orderHeader = await _context.OrderHeader.ToListAsync();
                    return orderHeader;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.OrderHeader != null) _context.Dispose();
                }
            }
        }

    }
}
