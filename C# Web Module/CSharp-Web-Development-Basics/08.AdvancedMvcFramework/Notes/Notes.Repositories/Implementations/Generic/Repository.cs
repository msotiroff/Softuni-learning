namespace Notes.Repositories.Implementations.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Contracts.Generic;
    using Microsoft.EntityFrameworkCore;

    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
            => this.context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities)
            => this.context.Set<TEntity>().AddRange(entities);

        public IEnumerable<TEntity> All()
            => this.context.Set<TEntity>().ToList();
        
        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
            => this.context.Set<TEntity>().Where(predicate).ToList();

        public TEntity Get(int id)
            => this.context.Set<TEntity>().Find(id);

        public void Remove(TEntity entity)
            => this.context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => this.context.Set<TEntity>().RemoveRange(entities);

        public int Commit() 
            => this.context.SaveChanges();

        public void Dispose()
            => this.context.Dispose();
    }
}
