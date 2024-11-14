using Microsoft.EntityFrameworkCore;
using RockPaperScissorsLizardSpock.Application.Interfaces.Repositories;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.DbContext;
using System.Linq.Expressions;

namespace RockPaperScissorsLizardSpock.Infrastructure.Persistance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly GameDbContext _dbContext;

        public GenericRepository(GameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            T? t = await _dbContext.Set<T>().FindAsync(id);
            return t;
        }

        public virtual async Task<IReadOnlyList<T>> GetAsync(
           string includeProperties = "",
           Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            foreach (var includeProperty in includeProperties
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))

            {
                query = query.Include(includeProperty);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();

        }

        public async Task<T> Add(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> AddWithLoadingNavigationProperties(T entity, List<string> navigationProperties)
        {
            foreach (var navigationProperty in navigationProperties)
            {
                _dbContext.Entry(entity).Reference(navigationProperty).Load();
            }   

            _dbContext.Entry(entity).State = EntityState.Added;
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
