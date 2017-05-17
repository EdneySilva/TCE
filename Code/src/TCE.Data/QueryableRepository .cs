using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCE.Core;

namespace TCE.Data
{
    struct QueryableRepository<T> : IQueryableRepository<T> where T : class
    {
        IQueryable<T> QueryItem { get; set; }

        public QueryableRepository(DbSet<T> item)
        {
            QueryItem = item;
        }

        public IQueryable<T> AsQueryable()
        {
            return this.QueryItem;
        }

        public IQueryableRepository<T> Include<TProperty>(Expression<Func<T, TProperty>> property)
        {
            QueryItem = QueryItem.Include(property);
            return this;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return QueryItem = QueryItem.Where(where);            
        }        
    }
}
