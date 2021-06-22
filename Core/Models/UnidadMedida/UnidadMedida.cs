using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Core.Models.UnidadMedida
{
    public class UnidadMedida
    {
        public static IEnumerable<UnidadMedida_model> SelectAll()
        {

            using (
                var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                )
            {
                var parameters = new DynamicParameters();



                cnn.Open();
                var rs =
                    cnn.Query<UnidadMedida_model>("sp_Cat_UnidadMedida_SelectAll", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;
            }
        }

        public static IEnumerable<UnidadMedida_model> MergeRow(UnidadMedida_model cat_unidadmedida)
        {
            using (
                     var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                     )
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", cat_unidadmedida.Id);
                parameters.Add("@UnidadMedida", cat_unidadmedida.UnidadMedida);
                parameters.Add("@Estatus", cat_unidadmedida.Estatus);
                cnn.Open();
                var rs =
                                 cnn.Query<UnidadMedida_model>("sp_Cat_UnidadMedida_Merge", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;

            }
        }

        public static IEnumerable<UnidadMedida_model> DeleteRow(int Id)
        {
            using (
                     var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                     )
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                cnn.Open();
                var rs =
                                 cnn.Query<UnidadMedida_model>("sp_Cat_UnidadMedida_Delete", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;

            }
        }


    }
}