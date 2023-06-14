using Microsoft.EntityFrameworkCore;
using OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts;

namespace OnlineShop.MarketPlace.Monolithic.Models.Services.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OnlineShopDbContext _context;

        public OrderDetailRepository(OnlineShopDbContext context)
        {
            _context= context;
        }
        public async Task<List<OrderDetail>> Select()
        {
            using(_context)
            {
                try
                {
                    var orderDetail = await _context.OrderDetail.ToListAsync();
                    return orderDetail;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.OrderDetail != null) _context.Dispose();
                }
            }
        }
    }
}
