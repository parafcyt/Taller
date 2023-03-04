using Domain.BaseEntity;
using System.Linq.Expressions;

namespace Domain.Repositories.Base
{
    public interface IRepository<T> where T : Entity
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

        /// <summary>
        /// Retorna un IQueryable para utilizar con GraphQL
        /// </summary>
        /// <returns></returns>
        IQueryable<T> AsQueryable();

        /// <summary>
        /// Obtiene un elemento en base a un predicado
        /// </summary>
        /// <param name="pPredicate"></param>
        /// <returns></returns>
        Task<T?> GetAsync(Expression<Func<T, bool>> pPredicate);

        /// <summary>
        /// Obtiene una lista de elementos en base a un predicado
        /// </summary>
        /// <param name="pPredicate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> pPredicate);
    }
}
