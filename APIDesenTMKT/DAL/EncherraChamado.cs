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
    public class EncherraChamadoDAL
    {
        string conn = "";
        public EncherraChamadoDAL(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        public List<EncerraChamado> GetEncerraChamado(string usuario)
        {

            System.Data.SqlClient.SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            List<EncerraChamado> arrayObjGetEnc = new List<EncerraChamado>();

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_GET_CHAMADOS_ENCERRADOS_USUARIO";
            comando.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = usuario;
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();

            if(ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    arrayObjGetEnc.Add(new Models.EncerraChamado());
                    arrayObjGetEnc[i].ChaCodigo = Convert.ToInt32(ds.Tables[0].Rows[i]["CHA_CODIGO"]);
                    arrayObjGetEnc[i].ChaDataAbertura = Convert.ToDateTime(ds.Tables[0].Rows[0]["CHA_DATAABERTURA"].ToString());
                    arrayObjGetEnc[i].ChaSolicitante = ds.Tables[0].Rows[i]["CHA_SOLICITANTE"].ToString();
                    arrayObjGetEnc[i].TpcDescricao = ds.Tables[0].Rows[i]["TPC_DESCRICAO"].ToString();
                    arrayObjGetEnc[i].CliNome = ds.Tables[0].Rows[i]["CLI_NOME"].ToString();
                    arrayObjGetEnc[i].AplNome = ds.Tables[0].Rows[i]["APL_NOME"].ToString();
                    arrayObjGetEnc[i].AnlNome = ds.Tables[0].Rows[i]["ANL_NOME"].ToString();
                    arrayObjGetEnc[i].ChaDescricao = ds.Tables[0].Rows[i]["CHA_DESCRICAO"].ToString();
                    arrayObjGetEnc[i].ChaDataEncerramento = Convert.ToDateTime(ds.Tables[0].Rows[0]["CHA_DATAENCERRAMENTO"].ToString());
                    arrayObjGetEnc[i].ChaTitulo = ds.Tables[0].Rows[i]["CHA_TITULO"].ToString();

                }

            }
            return arrayObjGetEnc;
        }

    }
}
