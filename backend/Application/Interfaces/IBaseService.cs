using Domain.BaseEntity;
using System.Linq.Expressions;

namespace Application.Interfaces
{
    public interface IBaseService<T> where T : Entity
    {
        Task<T?> GetByIdAsync(int pId);

        Task<T?> GetAsync(Expression<Func<T, bool>> pPredicate);

        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> pPredicate);

        IQueryable<T> GetQueryable();

        Task<T> AddAsync(T pInput);

        Task<T> UpdateAsync(T pInput);

        Task DeleteAsync(int pId);
    }
}
