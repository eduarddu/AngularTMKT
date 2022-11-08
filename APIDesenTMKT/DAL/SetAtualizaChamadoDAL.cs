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
    public class SetAtualizaChamadoDAL
    {

        string conn = "";
        public SetAtualizaChamadoDAL(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        #region Método para atualizar o chamado

        public void SetAtualizaChamado(Models.SetAtualizaChamado objAtu)
        {
            System.Data.SqlClient.SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_ATUALIZA_CHAMADO";

            comando.Parameters.Add("@CHA_CODIGO", SqlDbType.Int).Value = objAtu.ChaCodigo;
            comando.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = objAtu.Status;
            comando.Parameters.Add("@AGTCODIGO_RESPONSAVEL", SqlDbType.VarChar).Value = objAtu.AgtCodigo == null ? "" : objAtu.AgtCodigo;
            if (objAtu.Prazo == null)
            {
                comando.Parameters.Add("@PRAZO", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                comando.Parameters.Add("@PRAZO", SqlDbType.DateTime).Value = Convert.ToDateTime(objAtu.Prazo.ToString());
            }
            comando.CommandTimeout = 3000;
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();



        }


        #endregion



    }
}

