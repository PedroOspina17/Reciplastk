using Microsoft.EntityFrameworkCore;
using RecuperApp.Domain.Models.EntityModels.Base;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace RecuperApp.Domain.Repositories
{
    public class ApplicationRepository<T> : IApplicationRepository<T> where T : BaseEntity
    {
        protected readonly ReciplastkContext db;

        public ApplicationRepository(ReciplastkContext _context)
        {
            db = _context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            //auditableEntity.CreatedBy = GetCurrentUser ToDo:
            entity.CreatedDate = DateTime.Now;
            entity.IsActive = true;
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            //entity.UpdatedBy = GetCurrentUser ToDo
            entity.IsActive = false;
            //context.Set<T>().Remove(entity);
            await db.SaveChangesAsync();
        }
        protected IQueryable<T> ApplyIncludes(List<string> include)
        {
            var result = db.Set<T>().AsQueryable();
            foreach (var includeItem in include)
            {
                result = result.Include(includeItem);
            }
            return result;
        }
        public async Task<List<T>> GetAllAsync(List<string> include = null)
        {
            var query = db.Set<T>().AsQueryable();
            if (include != null)
            {
                query = ApplyIncludes(include);
            }
            
            return await query.Where(p => p.IsActive).ToListAsync();
        }
        public async Task<List<T>> GetByParamAsync(Expression<Func<T, bool>> predicate, List<string> include = null)
        {
            var query = db.Set<T>().AsQueryable();
            if (include != null)
            {
                query = ApplyIncludes(include);
            }

            return await query.Where(p => p.IsActive).Where(predicate).ToListAsync();
        }
        public async Task<T> FindByIdAsync(int id, List<string> include = null)
        {
            var query = db.Set<T>().AsQueryable();
            if (include != null)
            {
                query = ApplyIncludes(include);
            }
            return await query.Where(p => p.IsActive && p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> FindByParamAsync(Expression<Func<T, bool>> predicate, List<string> include = null)
        {
            var query = db.Set<T>().AsQueryable();
            if (include != null)
            {
                query = ApplyIncludes(include);
            }
            return await query.Where(p => p.IsActive).Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            //entity.UpdatedBy = GetCurrentUser ToDo
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
