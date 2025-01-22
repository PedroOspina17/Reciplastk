using System.Linq.Expressions;

namespace RecuperApp.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByParam(Expression<Func<T, bool>> predicate);
    }
}
