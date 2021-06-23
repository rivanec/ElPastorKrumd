using Core.Models.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Core.Controllers
{
    public class WaProductosController : ApiController
    {
        // GET: api/WaProductos
        public IEnumerable<Productos_model> Get()
        {

            return Prodcutos.SelectAll();
        }
        // POST: api/WaProductos
        public void Post(Productos_model value)
        {
            Prodcutos.MergeRow(value);
        }

        // GET: api/WaProductos
        [Route("api/WaProductos/Eliminar")]
        [HttpGet]
        public void Eliminar(int id)
        {
            Prodcutos.DeleteRow(id);
        }
    }
}
