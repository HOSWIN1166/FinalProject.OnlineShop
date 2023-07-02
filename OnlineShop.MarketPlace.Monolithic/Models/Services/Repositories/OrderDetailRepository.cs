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
            _context= context;
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
                OrderDetail.IsDeleted = true;
                _context.OrderDetail.Update(OrderDetail);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> InsertAsync(OrderHeader? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                await _context.OrderHeader.AddAsync(entity);
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
                bool isExist = (_context.OrderHeader?.Any(o => o.Id == id)).GetValueOrDefault();
                return (isExist, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (false, RepositoryStatus.NotExist);
            }
        }

        public async Task<(IEnumerable<OrderHeader?>?, RepositoryStatus)> SelectAllAsync()
        {
            try
            {
                var orderHeaders = await _context.OrderHeader.ToListAsync();
                if (orderHeaders == null || orderHeaders.Count == 0)
                    return (null, RepositoryStatus.TableIsEmpty);
                return (orderHeaders, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<(OrderHeader?, RepositoryStatus)> SelectByIdAsync(Guid? id)
        {
            try
            {
                var orderHeader = await _context.OrderHeader.FirstOrDefaultAsync(o => o.Id == id);
                if (orderHeader == null)
                    return (null, RepositoryStatus.NotExist);
                return (orderHeader, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<RepositoryStatus> UpdateAsync(OrderHeader? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                _context.OrderHeader.Update(entity);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;

            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }
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
