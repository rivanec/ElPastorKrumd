using Core.Models.UnidadMedida;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Core.Models.Categorias
{
    public class Categorias
    {
        public static IEnumerable<Categroias_model> SelectAll()
        {

            using (
                var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                )
            {
                var parameters = new DynamicParameters();



                cnn.Open();
                var rs =
                    cnn.Query<Categroias_model>("sp_Cat_Categorias_SelectAll", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;
            }
        }

        public static IEnumerable<Categroias_model> MergeRow(Categroias_model Categroias)
        {
            using (
                     var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                     )
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Categroias.Id);
                parameters.Add("@Categoria", Categroias.Categoria);
                parameters.Add("@Estatus", Categroias.Estatus);
                cnn.Open();
                var rs =
                                 cnn.Query<Categroias_model>("sp_Cat_Categorias_Merge", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;

            }
        }

        public static IEnumerable<Categroias_model> DeleteRow(int Id)
        {
            using (
                     var cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pastor"].ConnectionString)
                     )
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                cnn.Open();
                var rs =
                                 cnn.Query<Categroias_model>("sp_Cat_Categorias_Delete", parameters, commandType: CommandType.StoredProcedure).AsEnumerable();
                return rs;

            }
        }
    }
}