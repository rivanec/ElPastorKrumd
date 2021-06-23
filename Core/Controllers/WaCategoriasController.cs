using Core.Models.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Core.Controllers
{
    public class WaCategoriasController : ApiController
    {
        // GET: api/WaCategorias
        public IEnumerable<Categroias_model> Get()
        {

            return Categorias.SelectAll();
        }
        // POST: api/WaCategorias
        public void Post(Categroias_model value)
        {
            Categorias.MergeRow(value);
        }

        // GET: api/WaCategorias
        [Route("api/WaCategorias/Eliminar")]
        [HttpGet]
        public void Eliminar(int id)
        {
            Categorias.DeleteRow(id);
        }
    }
}
