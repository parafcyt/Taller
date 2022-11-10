using Domain.Repositories.Base;
using Infraestructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TallerContext iTallerContext;

        public Repository(TallerContext pTallerContext)
        {
            iTallerContext = pTallerContext;
        }

        private async Task SaveChanges()
        {
            await iTallerContext.SaveChangesAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await iTallerContext.Set<T>().AddAsync(entity);
            await SaveChanges();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            iTallerContext.Set<T>().Remove(entity);
            await SaveChanges();
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
            await SaveChanges();

            return entity;
        }

        public IQueryable<T> AsQueryable()
        {
            return iTallerContext.Set<T>().AsNoTracking();
        }
    }
}
