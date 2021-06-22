using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Core.Controllers
{
    public class prueaController : ApiController
    {
        // GET: api/pruea
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/pruea/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/pruea
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/pruea/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/pruea/5
        public void Delete(int id)
        {
        }
    }
}
