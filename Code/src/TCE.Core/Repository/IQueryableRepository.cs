using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TCE.Core
{
    public interface IQueryableRepository<T> where T : class
    {
        IQueryableRepository<T> Include<TProperty>(Expression<Func<T, TProperty>> property);
        IQueryable<T> Where(Expression<Func<T, bool>> where);
        IQueryable<T> AsQueryable();
    }
}
