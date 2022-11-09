
namespace Domain.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtener todos los elementos/entidades
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Obtener un elemento/entidad por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega un elemento/entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Actualiza un elemento/entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Elimina un elemento/entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        IQueryable<T> AsQueryable();
    }
}
