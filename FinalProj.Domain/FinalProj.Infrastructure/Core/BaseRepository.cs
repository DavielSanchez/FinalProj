﻿using FinalProj.Domain.Repository;
using FinalProj.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProj.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {  
        private readonly SalesContext context;

        private DbSet<TEntity> entities;

        public BaseRepository(SalesContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public virtual TEntity GetEntity(int Id)
        {
            return this.entities.Find(Id);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public virtual void Save(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }
    }
}