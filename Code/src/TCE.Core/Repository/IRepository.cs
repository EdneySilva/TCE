using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.Core
{
    public interface IRepository
    {
        IQueryableRepository<T> Use<T>() where T : class;
        Try<Exception, T> Save<T>(T entity) where T : class;
        Try<Exception, T> Delete<T>(T entity) where T : class;
    }
}
