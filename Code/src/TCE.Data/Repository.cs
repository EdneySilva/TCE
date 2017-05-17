using TCE.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCE.Core.Extensions;

namespace TCE.Data
{
    class Repository : DbContext, IRepository
    {
        DbSet<Entity> Entidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public Try<Exception, T> Save<T>(T entity) where T : class
        {
            return new RepositoryContext<T>(this, entity).Try((context) =>
            {
                if (context.Repository.Entry(context.Entity).IsKeySet)
                    context.Repository.Set<T>().Update(context.Entity);
                else
                    context.Repository.Set<T>().Add(context.Entity);
                context.Repository.SaveChanges();
                return entity;
            });
        }
        
        public Try<Exception, T> Delete<T>(T entity) where T : class
        {
            return new RepositoryContext<T>(this, entity).Try((context) =>
            {
                context.Repository.Remove(entity);
                context.Repository.SaveChanges();
                return entity;
            });
        }

        public IQueryableRepository<T> Use<T>() where T : class
        {
            return new QueryableRepository<T>(this.Set<T>());
        }

        struct RepositoryContext<T>
        {
            internal Repository Repository { get; }
            internal T Entity { get; }
            public RepositoryContext(Repository repository, T entity)
            {
                Repository = repository;
                Entity = entity;
            }
        }
    }
}
