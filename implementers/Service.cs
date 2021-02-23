using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using splendor.net5.core.commons;
using splendor.net5.core.contracts;
using splendor.net5.core.enums;
using splendor.net5.core.exceptions;

namespace splendor.net5.core.implementers
{
    /// <summary>
    /// Base service abstract class. This class aims to implement layer of simple logic. 
    /// This layer uses repository layer
    /// </summary>
    /// <typeparam name="E">Entity type</typeparam>
    /// <typeparam name="K">Primary key type</typeparam>
    /// <typeparam name="TO">Transfer object type</typeparam>
    public abstract class Service<E, K, TO> : IDisposable
        where E : class, new()
        where TO : TObject
    {
        protected readonly IRepository<E, K> _repository;
        protected readonly ITracer _tracer;
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ITransaction _transaction;
        public Service(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _repository = _serviceProvider.GetService(typeof(IRepository<E, K>)) as IRepository<E, K>;
            _tracer = _serviceProvider.GetService(typeof(DefaultTracer)) as ITracer;
            _transaction = _serviceProvider.GetService(typeof(TSTransaction)) as ITransaction;
            ValidateDependencyInjection(typeof(DefaultTracer), typeof(TSTransaction));
        }

        public Service(
            IServiceProvider serviceProvider,
            Type tracerType)
        {
            _serviceProvider = serviceProvider;
            _repository = _serviceProvider.GetService(typeof(IRepository<E, K>)) as IRepository<E, K>;
            _tracer = _serviceProvider.GetService(tracerType) as ITracer;
            _transaction = _serviceProvider.GetService(typeof(TSTransaction)) as ITransaction;
            ValidateDependencyInjection(tracerType, typeof(TSTransaction));
        }

        public Service(
            IServiceProvider serviceProvider,
            Type tracerType,
            Type transactionType)
        {
            _serviceProvider = serviceProvider;
            _repository = _serviceProvider.GetService(typeof(IRepository<E, K>)) as IRepository<E, K>;
            _tracer = _serviceProvider.GetService(tracerType) as ITracer;
            _transaction = _serviceProvider.GetService(transactionType) as ITransaction;
            ValidateDependencyInjection(tracerType, transactionType);
        }

        private void ValidateDependencyInjection(
            Type tracerType, 
            Type transactionType
        )
        {
            if(_repository is null) throw new InvalidOperationException($"No found type \"{typeof(IRepository<E, K>).Name}\" in service provider");
            if(_tracer is null) throw new InvalidOperationException($"No found type \"{tracerType.Name}\" in service provider");
            if(_transaction is null) throw new InvalidOperationException($"No found type \"{transactionType.Name}\" in service provider");
        }

        protected internal virtual async Task<E> Get(K id) => await _repository.Get(id);
        protected internal virtual async Task<E> Single(K id) => (await _repository.Single(id)).SingleOrDefault();
        protected internal virtual async Task<List<E>> All() => (await _repository.All()).ToList();
        protected internal virtual async Task<bool> Exists(E entity) => await _repository.Exists(entity);
        protected internal virtual async Task Add(E entity) => await _repository.Add(entity);
        protected internal virtual async Task Edit(E entity) => await _repository.Edit(entity);
        protected internal virtual async Task Remove(E entity) => await _repository.Add(entity);
        protected internal virtual async Task<List<E>> Page(DPagination pagination)
        => (await _repository.Page(pagination)).ToList();
        protected internal virtual async Task<long> Count(List<DFilter> filters)
        => await _repository.Count(filters);
        public abstract Task<E> MapEntity(TO to);
        public abstract TO MapTO(E entity);
        public virtual Task MapReturnAdd(E entity, TO to) => Task.CompletedTask;
        public virtual Task MapReturnEdit(E entity, TO to) => Task.CompletedTask;
        public virtual Task<TO> MapSmartTO(E entity) => Task.FromResult(default(TO));
        public virtual Task CustomAddValidation(E entity, TO to, ReplyTO<E, TO> reply) => Task.CompletedTask;
        public virtual Task CustomEditValidation(E entity, TO to, ReplyTO<E, TO> reply) => Task.CompletedTask;
        public virtual Task IntegrityValidate(E entity, TO to, ReplyTO<E, TO> reply) => Task.CompletedTask;
        public virtual Task ByAdd(E entity, TO to, ReplyTO<E, TO> reply) => Task.CompletedTask;
        public virtual Task ByEdit(E entity, TO to, ReplyTO<E, TO> reply) => Task.CompletedTask;
        public virtual Task ByRemove(E entity, TO to, ReplyTO<E, TO> reply) => Task.CompletedTask;
        public virtual Task AfterRemove(ReplyTO<E, TO> reply) => Task.CompletedTask;
        public virtual async Task<ReplyTO<E, TO>> GetTO(K id)
        {
            ReplyTO<E, TO> reply = new();
            await CommandStoreException.Handle(async () =>
            {
                E entity = (await _repository.Single(id)).SingleOrDefault();
                if (reply.Success = entity != null)
                {
                    reply.Value = await MapSmartTO(entity);
                    reply.Value ??= MapTO(entity);
                }
                else
                {
                    reply.Error = AppError.NOT_EXISTS;
                }
            }, _repository, CommandStore.QUERY, id);
            return reply;
        }
        public virtual async Task<ReplyTO<E, TO>> PageTO(DPagination pagination)
        {
            List<TO> rows = (await _repository.Page(pagination)).Select(e => MapTO(e)).ToList();
            long count = await _repository.Count(pagination.DFilters);
            return new ReplyTO<E, TO> { Rows = rows, Count = count };
        }
        public virtual async Task<List<TO>> AllTO()
        {
            return (await _repository.All()).Select(e => MapTO(e)).ToList();
        }
        public virtual async Task<ReplyTO<E, TO>> AddTO(TO to, bool returning = false)
        {
            ReplyTO<E, TO> reply = new() { Value = to };
            await _transaction.Begin(async () =>
            {
                await CommandStoreException.Handle(async () =>
                {
                    if(!to.Valid) throw new TransferObjectInvalidException(to);
                    E entity = await MapEntity(to);
                    if (!await _repository.Exists(entity))
                    {
                        await CustomAddValidation(entity, to, reply);
                        if (reply.Success)
                        {
                            await _tracer.TraceAdd(entity, to.Trace);
                            await ByAdd(entity, to, reply);
                            await Add(entity);
                            if (returning)
                            {
                                await _repository.ForceCommit();
                                await MapReturnAdd(entity, to);
                            }
                            reply.Entity = entity;
                        }
                    }
                    else
                    {
                        reply.Success = false;
                        reply.Error = AppError.DUPLICATED;
                    }
                }, _repository, CommandStore.ADD, data: to);
            });
            return reply;
        }

        public virtual async Task<ReplyTO<E, TO>> EditTO(K id, TO to, bool returning = false)
        {
            ReplyTO<E, TO> reply = new() { Value = to };
            await _transaction.Begin(async () =>
            {
                await CommandStoreException.Handle(async () =>
                {
                    if(!to.Valid) throw new TransferObjectInvalidException(to);
                    E mockEntity = await MapEntity(to);
                    if (!(reply.Success = !await _repository.Exists(mockEntity)))
                    {
                        await CustomEditValidation(mockEntity, to, reply);
                        if (reply.Success)
                        {
                            E entity = (await _repository.Single(id)).SingleOrDefault();
                            if (reply.Success = entity is not null)
                            {
                                await _tracer.TraceEdit(entity, to.Trace);
                                await ByEdit(entity, to, reply);
                                await Edit(entity);
                                if (returning)
                                {
                                    await _repository.ForceCommit();
                                    await MapReturnEdit(entity, to);
                                }
                                reply.Entity = entity;
                            }
                            else
                            {
                                reply.Error = AppError.NOT_EXISTS;
                            }
                        }
                    }
                    else
                    {
                        reply.Error = AppError.DUPLICATED;
                    }
                }, _repository, CommandStore.EDIT, data: to);
            });
            return reply;
        }

        public virtual async Task<ReplyTO<E, TO>> RemoveTO(K id, TO to)
        {
            ReplyTO<E, TO> reply = new();
            await _transaction.Begin(async () =>
            {
                await CommandStoreException.Handle(async () =>
                {
                    E entity = (await _repository.Single(id)).SingleOrDefault();
                    if (reply.Success = entity is not null)
                    {
                        await IntegrityValidate(entity, to, reply);
                        if (reply.Success)
                        {
                            await _tracer.TraceEdit(entity, to.Trace);
                            await ByRemove(entity, to, reply);
                            await Remove(entity);
                            reply.Value = MapTO(entity);
                            reply.Entity = entity;
                            await AfterRemove(reply);
                        }
                        else
                        {
                            reply.Error = AppError.INTEGRITY;
                        }
                    }
                    else
                    {
                        reply.Error = AppError.NOT_EXISTS;
                    }
                }, _repository, CommandStore.REMOVE, to);
            });
            return reply;
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
            _transaction.Dispose();
        }
    }
}