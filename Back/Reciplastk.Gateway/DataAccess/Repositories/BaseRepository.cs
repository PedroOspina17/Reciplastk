using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Reciplastk.Gateway.DataAccess.Repositories
{
        public class BaseRepository<T> : IBaseRepository<T> where T : class
        {
            private readonly ReciplastkContext context;

            public BaseRepository(ReciplastkContext _context)
            {
                context = _context;
            }
            public async Task<T> CreateAsync(T entity)
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }

            public async Task DeleteAsync(T entity)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }

            public async Task<List<T>> GetAllAsync()
            {
                return await context.Set<T>().ToListAsync();
            }

            public async Task<T> GetByParam(Expression<Func<T, bool>> predicate)
            {
                return await context.Set<T>().Where(predicate).FirstOrDefaultAsync();
            }

            public async Task<T> UpdateAsync(T entity)
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }
        }
}
