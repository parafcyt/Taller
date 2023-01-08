
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T?> GetByIdAsync(int pId);

        Task<T?> GetAsync(Expression<Func<T, bool>> pPredicate);

        IQueryable<T> GetAllAsync();

        Task<T> AddAsync(T pInput);

        Task<T> UpdateAsync(T pInput);

        Task DeleteAsync(int pId);
    }
}
