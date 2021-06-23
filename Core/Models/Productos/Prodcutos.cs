using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Core.Models.Productos
{
    public class Prodcutos
    {
        public static IEnumerable<Productos_model> SelectAll()
        {

            using (
                var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                )
            {
                var parameters = new DynamicParameters();



                cnn.Open();
                var rs =
                    cnn.Query<Productos_model>("sp_Cat_Productos_SelectAll", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;
            }
        }

        public static IEnumerable<Productos_model> MergeRow(Productos_model cat_productos)
        {
            using (
                     var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                     )
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", cat_productos.Id);
                parameters.Add("@Producto", cat_productos.Producto);
                parameters.Add("@ImagenUrl", cat_productos.ImagenUrl);
                parameters.Add("@Precio", cat_productos.Precio);
                parameters.Add("@Estatus", cat_productos.Estatus);
                parameters.Add("@CategoriaId", cat_productos.CategoriaId);
                cnn.Open();
                var rs =
                                 cnn.Query<Productos_model>("sp_Cat_Productos_Merge", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;

            }
        }

        public static IEnumerable<Productos_model> DeleteRow(int Id)
        {
            using (
                     var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                     )
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                cnn.Open();
                var rs =
                                 cnn.Query<Productos_model>("sp_Cat_Productos_Delete", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;

            }
        }
    }
}