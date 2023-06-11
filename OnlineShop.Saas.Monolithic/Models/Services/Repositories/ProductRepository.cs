using Microsoft.EntityFrameworkCore;
using OnlineShop.Saas.Monolithic.Models.DomainModels.ProductAggregates;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;

namespace OnlineShop.Saas.Monolithic.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineShopDbContext _context;
        public ProductRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Select()
        {
            using (_context)
            {
                try
                {

                    var products = await _context.Product.ToListAsync();
                    return products;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (_context.Product != null) _context.Dispose();
                }
            }
        }
    }
}
