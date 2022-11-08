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

        public int SetAbreChamado(int ctrCodigo, string agtCodigo, int aplCodigo, int atcCodigo, string descricao, string titulo)
        {
            SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
          

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_ABRE_CHAMADO";
            comando.Parameters.Add("@AGT_CODIGO", SqlDbType.VarChar).Value = agtCodigo;
            comando.Parameters.Add("@APL_CODIGO", SqlDbType.Int).Value = aplCodigo;
            comando.Parameters.Add("@DESCRICAO", SqlDbType.VarChar).Value = descricao;
            comando.Parameters.Add("@ATC_CODIGO", SqlDbType.Int).Value = atcCodigo;
            comando.Parameters.Add("@CTR_CODIGO", SqlDbType.Int).Value = ctrCodigo;
            comando.Parameters.Add("@TITULO", SqlDbType.VarChar).Value = titulo;
            comando.CommandTimeout = 3000000;
            try
            {
                conexao.Open();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(ds, "data");
                conexao.Close();
                return Convert.ToInt32(ds.Tables[0].Rows[0]["CHA_CODIGO"]);
            }
            catch (Exception ex)
            {
                return -1;
            }
            //return "Demanda " + objAbreChamado.CHACodigo.ToString() + " aberto com a área de desenvolvimento";

        }
        
    }
}
