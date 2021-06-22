using Core.Models.UnidadMedida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Models.Ingredientes
{
    public class Ingredientes_model 
    {
        public int Id { get; set; }

        public string Ingrediente { get; set; }

        public int UnidadMedidaId { get; set; }

        public decimal Cantidad { get; set; }

        public int Estatus { get; set; }

        public string UnidadMedida { get; set; }


    }
}