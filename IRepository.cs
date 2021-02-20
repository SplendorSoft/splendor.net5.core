using System;
using System.Linq;
using System.Threading.Tasks;

namespace splendor.net5.core
{
    /// <summary>
    /// Basic repository contract
    /// </summary>
    /// <typeparam name="E">Entity class type</typeparam>
    /// <typeparam name="K">Primary key native type</typeparam>
    public interface IRepository<E, K> : IDisposable
        where E: class, new() 
    {
        /// <summary>
        /// Add E entity instance in data store
        /// </summary>
        /// <param name="entity">E entity instance</param>
        /// <returns>Task</returns>
        Task Add(E entity);

        /// <summary>
        /// Remove E entity instance on data store
        /// </summary>
        /// <param name="entity">E entity instance</param>
        /// <returns>Task</returns>
        Task Remove(E entity);

        /// <summary>
        /// Return E entity instance from data store by id
        /// </summary>
        /// <param name="id">primary key type K</param>
        /// <returns>E entity</returns>
        Task<E> Get(K id);

        /// <summary>
        /// Return Queryable instance for single instance by id
        /// </summary>
        /// <param name="key">primary key type K</param>
        /// <returns>Queryable instance</returns>
        Task<IQueryable<E>> Single(K key);

        /// <summary>
        /// Return Queryable instance for all instances
        /// </summary>
        /// <returns>Queryable instance for all entity records</returns>
        Task<IQueryable<E>> All();

        /// <summary>
        /// Verify exists entity instance in data store
        /// </summary>
        /// <param name="entity">E entity instance</param>
        /// <returns>true or false</returns>
        Task<bool> Exists(E entity) => Task.FromResult(false);
    }
}
