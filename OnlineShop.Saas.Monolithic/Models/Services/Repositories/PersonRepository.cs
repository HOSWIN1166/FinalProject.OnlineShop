using Microsoft.EntityFrameworkCore;
using OnlineShop.Saas.Monolithic.Models.DomainModels.PersonAggregates;
using OnlineShop.Saas.Monolithic.Models.Services.Contracts;
using OnlineShop.Saas.Monolithic.Models.Services.Statuses;

namespace OnlineShop.Saas.Monolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository<Guid?, bool, RepositoryStatus>
    {
        private readonly OnlineShopDbContext _context;

        public PersonRepository(OnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<RepositoryStatus> DeleteAsync(Person? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                entity.IsDelete = true;
                _context.Person.Update(entity);
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
                var Person = await _context.Person.FirstOrDefaultAsync(o => o.Id == id);
                if (Person == null) return RepositoryStatus.NullEntity;
                Person.IsDelete = true;
                _context.Person.Update(Person);
                await _context.SaveChangesAsync();
                return RepositoryStatus.Success;
            }
            catch (Exception)
            {
                return RepositoryStatus.DatabaseError;
            }
        }

        public async Task<RepositoryStatus> InsertAsync(Person? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                await _context.Person.AddAsync(entity);
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
                bool isExist = (_context.Person?.Any(o => o.Id == id)).GetValueOrDefault();
                return (isExist, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (false, RepositoryStatus.NotExist);
            }
        }

        public async Task<(IEnumerable<Person?>?, RepositoryStatus)> SelectAllAsync()
        {
            try
            {
                var Person = await _context.Person.ToListAsync();
                if (Person == null || Person.Count == 0)
                    return (null, RepositoryStatus.TableIsEmpty);
                return (Person, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<(Person?, RepositoryStatus)> SelectByIdAsync(Guid? id)
        {
            try
            {
                var Person = await _context.Person.FirstOrDefaultAsync(o => o.Id == id);
                if (Person == null)
                    return (null, RepositoryStatus.NotExist);
                return (Person, RepositoryStatus.Success);
            }
            catch (Exception)
            {
                return (null, RepositoryStatus.DatabaseError);
            }
        }

        public async Task<RepositoryStatus> UpdateAsync(Person? entity)
        {
            try
            {
                if (entity == null)
                    return RepositoryStatus.NullEntity;
                _context.Person.Update(entity);
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
