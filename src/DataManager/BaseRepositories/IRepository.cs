﻿using System;
using Database.BaseEntities;
using DataManager.BaseUnitsOfWork;

namespace DataManager.BaseRepositories
{
    public interface IRepository<TEntity> : IRepository<TEntity, Guid>
        where TEntity : class, IEntity<Guid>, new()
    {
    }

    public interface IRepository<TEntity, TKey> : IRepositoryCommon<TEntity, TKey>,
        IRepositorySync<TEntity, TKey>, IRepositoryAsync<TEntity, TKey>, IUnitOfWork
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct, IEquatable<TKey>
    {
    }
}