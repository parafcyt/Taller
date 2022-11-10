
namespace Application.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T?> GetByIdAsync(int pId);

        IQueryable<T> GetAllAsync();

        Task<T> AddAsync(T pInput);

        Task<T> UpdateAsync(T pInput);

        Task DeleteAsync(int pId);
    }
}
