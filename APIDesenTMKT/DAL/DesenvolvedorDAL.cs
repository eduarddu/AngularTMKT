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
    public class DesenvolvedorDAL
    {
        string conn = "";
        public DesenvolvedorDAL(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        public List<Desenvolvedor> GetConsultaDev()
        {
            System.Data.SqlClient.SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            List<Desenvolvedor> arrayDev = new List<Desenvolvedor>();

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_SELECIONA_DESENVOLVEDORES";
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    arrayDev.Add(new Models.Desenvolvedor());
                    arrayDev[i].nrreg = ds.Tables[0].Rows[i]["NRREG"].ToString();
                    arrayDev[i].nomeAbrev = ds.Tables[0].Rows[i]["NOME_ABREV"].ToString();
                }
            }


            return arrayDev;
        }



    }
}
