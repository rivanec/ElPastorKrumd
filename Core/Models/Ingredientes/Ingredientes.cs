using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Core.Models.Ingredientes
{
    public class Ingredientes
    {
        public static IEnumerable<Ingredientes_model> SelectAll()
        {

            using (
                var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                )
            {
                var parameters = new DynamicParameters();



                cnn.Open();
                var rs =
                    cnn.Query<Ingredientes_model>("sp_CAT_INGREDIENTES_SelectAll", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;
            }

        }


        public static IEnumerable<Ingredientes_model> MergeRow(Ingredientes_model cat_ingredientes)
        {
            using (
                     var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                     )
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", cat_ingredientes.Id);
                parameters.Add("@Ingrediente", cat_ingredientes.Ingrediente);
                parameters.Add("@UnidadMedidaId", cat_ingredientes.UnidadMedidaId);
                parameters.Add("@Cantidad", cat_ingredientes.Cantidad);
                parameters.Add("@Estatus", cat_ingredientes.Estatus);
                cnn.Open();
                var rs =
                                 cnn.Query<Ingredientes_model>("sp_CAT_INGREDIENTES_Merge", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;

            }
        }

        public static IEnumerable<Ingredientes_model> DeleteRow(int Id)
        {
            using (
                     var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
                     )
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                cnn.Open();
                var rs =
                                 cnn.Query<Ingredientes_model>("sp_CAT_INGREDIENTES_DeleteRow", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;

            }
        }

    }

}