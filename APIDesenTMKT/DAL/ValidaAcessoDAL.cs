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

        public List<ValidaAcesso> getValidaAcesso(string AgtCodigo, string Senha)
        {
            SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            List<ValidaAcesso> arrayValidaAcesso = new List<ValidaAcesso>();

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_VALIDA_ACESSO_USUARIO";
            comando.Parameters.Add("@AGT_CODIGO",SqlDbType.VarChar).Value = AgtCodigo;
            comando.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = Senha;
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    arrayValidaAcesso.Add(new Models.ValidaAcesso());
                    arrayValidaAcesso[i].Nome = ds.Tables[0].Rows[i]["NOME"].ToString();
                    arrayValidaAcesso[i].NomeAbrev = ds.Tables[0].Rows[i]["NOME_ABREV"].ToString();
                    arrayValidaAcesso[i].Email = ds.Tables[0].Rows[i]["EMAIL"].ToString();
                    arrayValidaAcesso[i].CtrCodigo = Convert.ToInt32(ds.Tables[0].Rows[i]["CTR_CODIGO"].ToString());
                    arrayValidaAcesso[i].CtrDescricao = ds.Tables[0].Rows[i]["CTR_DESCRICAO"].ToString();
                    arrayValidaAcesso[i].CgoDescricao = ds.Tables[0].Rows[i]["CGO_DESCRICAO"].ToString();
                    arrayValidaAcesso[i].SenhaCol = ds.Tables[0].Rows[i]["SENHA"].ToString();
                    arrayValidaAcesso[i].AcessoValido = Convert.ToBoolean(ds.Tables[0].Rows[i]["ACESSO_VALIDO"].ToString());
                    arrayValidaAcesso[i].MsgAcesso = ds.Tables[0].Rows[i]["MENSAGEM_ACESSO"].ToString();
                }


            }
            return arrayValidaAcesso;



        }
    }
}
