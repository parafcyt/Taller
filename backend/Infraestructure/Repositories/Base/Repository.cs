using Domain.BaseEntity;
using Domain.Repositories.Base;
using Infraestructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly TallerContext iTallerContext;

        public Repository(TallerContext pTallerContext)
        {
            iTallerContext = pTallerContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await iTallerContext.Set<T>().AddAsync(entity);
            await iTallerContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            iTallerContext.Set<T>().Remove(entity);
            await iTallerContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await iTallerContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await iTallerContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            iTallerContext.Set<T>().Update(entity);
            await iTallerContext.SaveChangesAsync();

            return entity;
        }

        public IQueryable<T> AsQueryable()
        {
            return iTallerContext.Set<T>().AsNoTracking();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> pPredicate)
        {
            return await iTallerContext.Set<T>().FirstOrDefaultAsync(pPredicate);
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> pPredicate)
        {
            return await iTallerContext.Set<T>().Where(pPredicate).ToListAsync();
        }
    }
}
