using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Models.Productos
{
    public class Productos_model
    {
		public int Id { get; set; }

		public string Producto { get; set; }

		public string ImagenUrl { get; set; }

		public decimal Precio { get; set; }

		public int Estatus { get; set; }

		public int CategoriaId { get; set; }

		public string Categoria { get; set; }

	}
}