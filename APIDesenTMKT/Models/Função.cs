using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using APIDesenTMKT.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data;
using System.Net;

namespace APIDesenTMKT.Models
{
    public class Função
    {
        string conn = "";
        public Função(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }


        public DataSet getValidaAcesso(string matricula, string senha)
        {
            DataSet ds = new DataSet();
            SqlCommand objCommand = new SqlCommand();
            SqlConnection conn = new SqlConnection("conn");

            objCommand.Connection = conn;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "STP_VALIDA_ACESSO_USUARIO";
            objCommand.Parameters.Add("@AGT_CODIGO", SqlDbType.VarChar).Value = matricula;
            objCommand.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = matricula;
            objCommand.CommandTimeout = 3000000;

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(objCommand);
                da.Fill(ds, "data");
                conn.Close();
                return ds;
            }
            catch
            {
                return null;
            }




        }
    }
}
