using System.Linq.Expressions;

namespace RecuperApp.Domain.Repositories
{
    public interface IApplicationRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync(List<string> include = null);
        Task<List<T>> GetByParamAsync(Expression<Func<T, bool>> predicate, List<string> include = null);
        Task<T> FindByIdAsync(int id, List<string> include = null);
        Task<T> FindByParamAsync(Expression<Func<T, bool>> predicate, List<string> include = null);
    }
}
