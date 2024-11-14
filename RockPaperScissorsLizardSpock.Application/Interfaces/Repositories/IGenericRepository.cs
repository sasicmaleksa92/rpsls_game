using System.Linq.Expressions;

namespace RockPaperScissorsLizardSpock.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAsync(
           string includeProperties = "",
           Expression<Func<T, bool>> filter = null);

        Task<T> Add(T entity);

        Task<T> AddWithLoadingNavigationProperties(T entity, List<string> navigationProperties);

        Task Update(T entity);

        Task Delete(T entity);

    }
}
