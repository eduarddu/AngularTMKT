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
    public class ValidaAcessoDAL
    {
        string conn = "";

        public ValidaAcessoDAL(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        public List<ValidaAcesso> GetValidaAcesso(string matricula, string senha)
        {
            System.Data.SqlClient.SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            List<ValidaAcesso> objValida = new List<ValidaAcesso>();

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_VALIDA_ACESSO_USUARIO";
            comando.Parameters.Add("@AGT_CODIGO", SqlDbType.VarChar).Value = matricula;
            comando.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = senha;
            comando.CommandTimeout = 3000000;
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objValida.Add(new Models.ValidaAcesso());
                    objValida[i].Nome = ds.Tables[0].Rows[0]["NOME"].ToString();
                    objValida[i].NomeAbrev = ds.Tables[0].Rows[0]["NOME_ABREV"].ToString();
                    objValida[i].Email = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                    objValida[i].CtrCodigo = Convert.ToInt32(ds.Tables[0].Rows[0]["CTR_CODIGO"]);
                    objValida[i].CtrDescricao = ds.Tables[0].Rows[0]["CTR_DESCRICAO"].ToString();
                    objValida[i].CgoDescricao = ds.Tables[0].Rows[0]["CGO_DESCRICAO"].ToString();
                    objValida[i].AcessoVal = Convert.ToBoolean(ds.Tables[0].Rows[0]["ACESSO_VALIDO"]);
                    objValida[i].MsgAcesso = ds.Tables[0].Rows[0]["MENSAGEM_ACESSO"].ToString();
                }
            }
            return objValida;


        }

        }
    }

