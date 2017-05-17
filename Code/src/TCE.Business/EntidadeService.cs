using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCE.Core;
using TCE.Core.Extensions;

namespace TCE.Business
{
    public class EntityService
    {
        IRepository Repository { get; }
        public EntityService(IRepository repository)
        {
            Repository = repository;
        }

        Entity Current { get; set; }

        public EntityService For(int id)
        {
            //Repositorio.Use

            return this;
        }

        public IQueryable<Entity> List()
        {
            return Repository.Use<Entity>().AsQueryable();
        }

        public Try<Exception, Entity> Save(Entity entity)
        {
            return Repository.Save(entity);
            // todo
        }

        public Try<Exception, Entity> Delete()
        {
            var entity = Current;
            Current = null;
            return Repository.Delete(entity);
            // todo
        }
    }
}
