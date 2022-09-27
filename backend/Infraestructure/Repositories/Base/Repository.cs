using Domain.Repositories.Base;
using Infraestructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TallerContext iTallerContext;

        public Repository(TallerContext pTallerContext)
        {
            iTallerContext = pTallerContext;
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await iTallerContext.Set<T>().ToListAsync();
        }

        public Task<T?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
