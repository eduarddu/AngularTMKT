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
    public class AbreChamadoDAL
    {
        string conn = "";
        public AbreChamadoDAL(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        public void SetAbreChamado(Models.AbreChamado objAbreChamado, int ctrCodigo, string agtCodigo, int aplCodigo, int atcCodigo, string descricao, string titulo)
        {
            SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_ABRE_CHAMADO";
            comando.CommandTimeout = 3000;
            comando.Parameters.Add("@AGT_CODIGO", SqlDbType.VarChar).Value = agtCodigo;
            comando.Parameters.Add("@APL_CODIGO", SqlDbType.Int).Value = aplCodigo;
            comando.Parameters.Add("@DESCRICAO", SqlDbType.VarChar).Value = descricao;
            comando.Parameters.Add("@ATC_CODIGO", SqlDbType.Int).Value = atcCodigo;
            comando.Parameters.Add("@CTR_CODIGO", SqlDbType.Int).Value = ctrCodigo;
            comando.Parameters.Add("@TITULO", SqlDbType.VarChar).Value = titulo;
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();
        }
    }
}
