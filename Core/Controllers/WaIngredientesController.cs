using Core.Models.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Core.Controllers
{
    public class WaIngredientesController : ApiController
    {
        // GET: api/WaIngredientes
        public IEnumerable<Ingredientes_model> Get()
        {

            return Ingredientes.SelectAll();
        }
        // POST: api/WaIngredientes
        public void Post(Ingredientes_model value)
        {
            Ingredientes.MergeRow(value);
        }

        // GET: api/WaIngredientes
        [Route("api/WaIngredientes/Eliminar")]
        [HttpGet]
        public void Eliminar(int id)
        {
            Ingredientes.DeleteRow(id);
        }


        [Route("api/WaIngredientes/Filter")]
        [HttpGet]
        public IEnumerable<Ingrediente_selectto> Filter(string filter = null)
        {
            return Ingredientes.Filter(filter);
        }
    }
}
