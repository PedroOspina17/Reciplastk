using Microsoft.EntityFrameworkCore;
using RecuperApp.Domain.Models.EntityModels.Base;
using System.Linq.Expressions;

namespace RecuperApp.Domain.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ReciplastkContext context;

        public BaseRepository(ReciplastkContext _context)
        {
            context = _context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            //auditableEntity.CreatedBy = GetCurrentUser ToDo:
            entity.CreatedDate = DateTime.Now;
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            //entity.UpdatedBy = GetCurrentUser ToDo
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
            entity.UpdatedDate = DateTime.Now;
            //entity.UpdatedBy = GetCurrentUser ToDo
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
