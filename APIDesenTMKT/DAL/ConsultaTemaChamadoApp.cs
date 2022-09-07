using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using APIDesenTMKT.Models;

namespace APIDesenTMKT.DAL
{
    public class ConsultaTemaChamadoAppDAL
    {
        string conn = "";

        public ConsultaTemaChamadoAppDAL(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        public List<ConsultaTemaChamadoApp> GetConsultaTemaChamadoApp(int AplCodigo)
        {
            System.Data.SqlClient.SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            List<ConsultaTemaChamadoApp> arrayObjConsTema = new List<ConsultaTemaChamadoApp>();

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_GET_TEMA_CHAMADO_APLICACAO";
            comando.CommandTimeout = 3000;
            comando.Parameters.Add("@APL_CODIGO", SqlDbType.Int).Value = AplCodigo;
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    arrayObjConsTema.Add(new Models.ConsultaTemaChamadoApp());
                    arrayObjConsTema[i].AplCodigo = Convert.ToInt32(ds.Tables[0].Rows[i]["ATC_CODIGO"]);
                    arrayObjConsTema[i].AtcDescricao = ds.Tables[0].Rows[i]["ATC_DESCRICAO"].ToString();
                }
            }
            return arrayObjConsTema;
        }
    }
}