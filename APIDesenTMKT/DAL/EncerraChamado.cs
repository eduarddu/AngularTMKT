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
    public class EncerraChamado
    {
        string conn = "";
        public EncerraChamado(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        public void setEncerraChamado(Models.EncerraChamado objEncerraCha, int chacodigo,string status)
        {
            SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_ENCERRA_CHAMADO";
            comando.CommandTimeout = 3000;
            comando.Parameters.Add("@CHA_CODIGO",SqlDbType.Int).Value = chacodigo;
            comando.Parameters.Add("@STATUS",SqlDbType.VarChar).Value = status;
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();
        }
    }
}
