using Microsoft.EntityFrameworkCore;
using OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Contracts;
using OnlineShop.MarketPlace.Monolithic.Models.Services.Statuses;

namespace OnlineShop.MarketPlace.Monolithic.Models.Services.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository<Guid?, bool, RepositoryStatus>
    {
        private readonly OnlineShopDbContext _context;

        public OrderDetailRepository(OnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<RepositoryStatus> DeleteAsync(OrderDetail? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                entity.IsDelete = true;
                _context.OrderDetail.Update(entity);
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
                var OrderDetail = await _context.OrderDetail.FirstOrDefaultAsync(o => o.Id == id);
                if (OrderDetail == null) return RepositoryStatus.NullEntity;
                OrderDetail.IsDelete = true;
                _context.OrderDetail.Update(OrderDetail);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> InsertAsync(OrderDetail? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                await _context.OrderDetail.AddAsync(entity);
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
                bool isExist = (_context.OrderDetail?.Any(o => o.Id == id)).GetValueOrDefault();
                return (isExist, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (false, RepositoryStatus.NotExist);
            }
        }

        public async Task<(IEnumerable<OrderDetail?>?, RepositoryStatus)> SelectAllAsync()
        {
            try
            {
                var OrderDetail = await _context.OrderDetail.ToListAsync();
                if (OrderDetail == null || OrderDetail.Count == 0)
                    return (null, RepositoryStatus.TableIsEmpty);
                return (OrderDetail, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<(OrderDetail?, RepositoryStatus)> SelectByIdAsync(Guid? id)
        {
            try
            {
                var OrderDetail = await _context.OrderDetail.FirstOrDefaultAsync(o => o.Id == id);
                if (OrderDetail == null)
                    return (null, RepositoryStatus.NotExist);
                return (OrderDetail, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<RepositoryStatus> UpdateAsync(OrderDetail? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                _context.OrderDetail.Update(entity);
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
