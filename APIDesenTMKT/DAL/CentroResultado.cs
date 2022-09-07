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
    public class CentroResultadoDAL
    {
        string conn = "";
        public CentroResultadoDAL(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        public List<CentroResultado> GetCentroResultado(int tipoBusca, int ctrCodigo, string agtCodigo)
        {
            System.Data.SqlClient.SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            List<CentroResultado> arrayObjCntResult = new List<CentroResultado>();

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_GET_CENTRO_RESULTADO";
            comando.Parameters.Add("@TIPO_BUSCA", SqlDbType.Int).Value = tipoBusca;
            comando.Parameters.Add("@AGT_CODIGO", SqlDbType.Int).Value = agtCodigo;
            comando.Parameters.Add("@CTR_CODIGO", SqlDbType.Int).Value = ctrCodigo;
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    arrayObjCntResult.Add(new Models.CentroResultado());
                    arrayObjCntResult[i].CtrCodigo = Convert.ToInt32(ds.Tables[0].Rows[i]["CTR_CODIGO"]);
                    arrayObjCntResult[i].CtrDescricao = ds.Tables[0].Rows[i]["CTR_DESCRICAO"].ToString();
                }
            }
            return arrayObjCntResult;
        }
    }
}
