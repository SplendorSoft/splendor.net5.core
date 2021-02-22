using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using splendor.net5.core.commons;

namespace splendor.net5.core.contracts
{
    /// <summary>
    /// Basic repository contract
    /// </summary>
    /// <typeparam name="E">Entity class type</typeparam>
    /// <typeparam name="K">Primary key native type</typeparam>
    public interface IRepository<E, K> : IDisposable
        where E : class, new()
    {
        /// <summary>
        /// Add E entity instance in data store
        /// </summary>
        /// <param name="entity">E entity instance</param>
        /// <returns>Task</returns>
        Task Add(E entity) => throw new NotImplementedException();

        /// <summary>
        /// Edit E entity instance in data store
        /// </summary>
        /// <param name="entity">E entity instance</param>
        /// <returns>Task</returns>
        Task Edit(E entity) => Task.CompletedTask;

        /// <summary>
        /// Remove E entity instance on data store
        /// </summary>
        /// <param name="entity">E entity instance</param>
        /// <returns>Task</returns>
        Task Remove(E entity) => throw new NotImplementedException();

        /// <summary>
        /// Return E entity instance from data store by id
        /// </summary>
        /// <param name="id">primary key type K</param>
        /// <returns>E entity</returns>
        Task<E> Get(K id) => throw new NotImplementedException();

        /// <summary>
        /// Return Queryable instance for single instance by id
        /// </summary>
        /// <param name="key">primary key type K</param>
        /// <returns>Queryable instance</returns>
        Task<IQueryable<E>> Single(K key) => throw new NotImplementedException();

        /// <summary>
        /// Return Queryable instance for all instances
        /// </summary>
        /// <returns>Queryable instance for all entity records</returns>
        Task<IQueryable<E>> All() => Task.FromResult(Enumerable.Empty<E>().AsQueryable());

        /// <summary>
        /// Verify exists entity instance in data store
        /// </summary>
        /// <param name="entity">E entity instance</param>
        /// <returns>true or false</returns>
        Task<bool> Exists(E entity) => Task.FromResult(false);

        /// <summary>
        /// Return queryable instance according to paging parameters
        /// </summary>
        /// <param name="pagination">Pagination parameters</param>
        /// <returns>Queryable instance for all entity records</returns>
        Task<IQueryable<E>> Page(DPagination pagination) => Task.FromResult(Enumerable.Empty<E>().AsQueryable());

        /// <summary>
        /// Return total record from storage according filters
        /// </summary>
        /// <param name="filters">Filters</param>
        /// <returns>Total records</returns>
        Task<long> Count(List<DFilter> filters) => Task.FromResult(default(long));

        Task ForceCommit() => Task.CompletedTask;
    }
}
