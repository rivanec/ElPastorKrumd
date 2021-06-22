using Core.Models.UnidadMedida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Core.Controllers
{
    public class WaUnidadMedidaController : ApiController
    {
        // GET: api/WaUnidadMedida
        public IEnumerable<UnidadMedida_model> Get()
        {

            return UnidadMedida.SelectAll();
        }
        // POST: api/WaUnidadMedida
        public void Post(UnidadMedida_model value)
        {
            UnidadMedida.MergeRow(value);
        }

        // GET: api/WaUnidadMedida
        [Route("api/WaUnidadMedida/Eliminar")]
        [HttpGet]
        public void Eliminar(int id)
        {
            UnidadMedida.DeleteRow(id);
        }

    }
}
