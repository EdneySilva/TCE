using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCE.Business;
using TCE.Core;
using TCE.Core.Extensions;

namespace TCE.Combustiveis.Controllers
{
    [Route("api/[controller]")]
    public class EntidadeController : Controller
    {
        EntityService EntidadeService { get; }
        public EntidadeController(EntityService entidadeService)
        {
            EntidadeService = entidadeService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            return EntidadeService.List().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Entity Get(int id)
        {
            return EntidadeService.List().Where(filtro => filtro.Id == id).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Entity value)
        {
            EntidadeService.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Entity value)
        {
            EntidadeService.Save(value).OnFail(this, (context, error) =>
            {
                return error.Message;
            }).OnSuccess((context, entity) =>
            {
                return $"The entity {entity.Id} was created";
            });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var result = EntidadeService.For(id)
            .Delete().OnFail(
                this, (context, error) =>
                {
                    return error.Message;
                }).OnSuccess((context, entidade) => {
                    return "The entity was removed";
                });
        }
    }
}
