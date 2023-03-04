using Application.Interfaces;
using Domain.BaseEntity;
using Domain.Repositories.Base;
using System.Linq.Expressions;

namespace Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : Entity
    {
        private readonly IRepository<T> iRepository;

        public BaseService(IRepository<T> pRepository)
        {
            iRepository = pRepository;
        }

        public async Task<T> AddAsync(T pInput)
        {
            return await iRepository.AddAsync(pInput);
        }

        public async Task DeleteAsync(int pId)
        {
            T? mEntity = await iRepository.GetByIdAsync(pId);

            if (mEntity != null)
            {
                await iRepository.DeleteAsync(mEntity);
            }
        }

        public IQueryable<T> GetQueryable()
        {
            return iRepository.AsQueryable();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> pPredicate)
        {
            return await iRepository.GetAsync(pPredicate);
        }

        public async Task<T?> GetByIdAsync(int pId)
        {
            return await iRepository.GetByIdAsync(pId);
        }

        public async Task<T> UpdateAsync(T pInput)
        {
            return await iRepository.UpdateAsync(pInput);
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> pPredicate)
        {
            return await iRepository.GetListAsync(pPredicate);
        }
    }
}
