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
    public class ConsultaAppDAL
    {
        string conn = "";
        public ConsultaAppDAL(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        public List<ConsultaApp> GetConsultaApp()
        {
            System.Data.SqlClient.SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            List<ConsultaApp> arrayApp = new List<ConsultaApp>();

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_GET_APLICACOES";
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    arrayApp.Add(new Models.ConsultaApp());
                    arrayApp[i].AplCodigo = Convert.ToInt32(ds.Tables[0].Rows[i]["APL_CODIGO"]);
                    arrayApp[i].AplNome = ds.Tables[0].Rows[i]["APL_NOME"].ToString();
                }
            }
            

            return arrayApp;
        }

    }
}