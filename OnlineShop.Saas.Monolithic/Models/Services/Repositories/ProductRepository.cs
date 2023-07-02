using Microsoft.EntityFrameworkCore;
using OnlineShop.Saas.Monolithic.Models.DomainModels.ProductAggregates;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;
using OnlineShop.Saas.Monolithic.Models.Services.Statuses;

namespace OnlineShop.Saas.Monolithic.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository<Guid?, bool, RepositoryStatus>
    {
        private readonly OnlineShopDbContext _context;
        public ProductRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<RepositoryStatus> DeleteAsync(Product? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                entity.IsDelete = true;
                _context.Product.Update(entity);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;

            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> DeleteByIdAsync(Guid? id)
        {
            try
            {
                var Product = await _context.Product.FirstOrDefaultAsync(o => o.Id == id);
                if (Product == null) return RepositoryStatus.NullEntity;
                Product.IsDelete = true;
                _context.Product.Update(Product);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> InsertAsync(Product? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                await _context.Product.AddAsync(entity);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public (bool, RepositoryStatus) IsExist(Guid? id)
        {
            try
            {
                bool isExist = (_context.Product?.Any(o => o.Id == id)).GetValueOrDefault();
                return (isExist, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (false, RepositoryStatus.NotExist);
            }
        }

        public async Task<(IEnumerable<Product?>?, RepositoryStatus)> SelectAllAsync()
        {
            try
            {
                var Product = await _context.Product.ToListAsync();
                if (Product == null || Product.Count == 0)
                    return (null, RepositoryStatus.TableIsEmpty);
                return (Product, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<(Product?, RepositoryStatus)> SelectByIdAsync(Guid? id)
        {
            try
            {
                var Product = await _context.Product.FirstOrDefaultAsync(o => o.Id == id);
                if (Product == null)
                    return (null, RepositoryStatus.NotExist);
                return (Product, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<RepositoryStatus> UpdateAsync(Product? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                _context.Product.Update(entity);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;

            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }
    }
}
