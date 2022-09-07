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
    public class GetChamadoDAL
    {
        string conn = "";
        public GetChamadoDAL(IConfiguration configuration)
        {

            conn = configuration.GetConnectionString("conn");
        }

        public List<GetChamado> GetChamado( bool atribuido)
        {
            System.Data.SqlClient.SqlConnection conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            List<GetChamado> arrayObjGetCha = new List<GetChamado>();

            comando.Connection = conexao;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "STP_GET_CHAMADOS_DESENV";
            comando.Parameters.Add("@ATRIBUIDO", SqlDbType.Bit).Value = atribuido;
            da = new SqlDataAdapter(comando);
            da.Fill(ds, "Dados");
            conexao.Close();

            if(atribuido == true) { 

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (atribuido == true) 
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        arrayObjGetCha.Add(new Models.GetChamado());
                        arrayObjGetCha[i].ChaCodigo = Convert.ToInt32(ds.Tables[0].Rows[i]["CHA_CODIGO"]);
                        arrayObjGetCha[i].ChaDataAbertura = Convert.ToDateTime(ds.Tables[0].Rows[0]["CHA_DATAABERTURA"].ToString());
                        arrayObjGetCha[i].ChaSolicitante = ds.Tables[0].Rows[i]["CHA_SOLICITANTE"].ToString();
                        arrayObjGetCha[i].TpcDescricao = ds.Tables[0].Rows[i]["TPC_DESCRICAO"].ToString();
                        arrayObjGetCha[i].CliNome = ds.Tables[0].Rows[i]["CLI_NOME"].ToString();
                        arrayObjGetCha[i].AplNome = ds.Tables[0].Rows[i]["APL_NOME"].ToString();
                        arrayObjGetCha[i].ChaPrazo = ds.Tables[0].Rows[0]["CHA_PRAZO"].ToString();
                        arrayObjGetCha[i].AnlNome = ds.Tables[0].Rows[i]["ANL_NOME"].ToString();
                        arrayObjGetCha[i].ChaDescricao = ds.Tables[0].Rows[i]["CHA_DESCRICAO"].ToString();
                        arrayObjGetCha[i].ChaTitulo = ds.Tables[0].Rows[i]["CHA_TITULO"].ToString();

                    }

                   
                }
            return arrayObjGetCha;
            }

            else
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (atribuido == false)
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            arrayObjGetCha.Add(new Models.GetChamado());
                            arrayObjGetCha[i].ChaCodigo = Convert.ToInt32(ds.Tables[0].Rows[i]["CHA_CODIGO"]);
                            arrayObjGetCha[i].ChaDataAbertura = Convert.ToDateTime(ds.Tables[0].Rows[0]["CHA_DATAABERTURA"].ToString());
                            arrayObjGetCha[i].ChaSolicitante = ds.Tables[0].Rows[i]["CHA_SOLICITANTE"].ToString();
                            arrayObjGetCha[i].TpcDescricao = ds.Tables[0].Rows[i]["TPC_DESCRICAO"].ToString();
                            arrayObjGetCha[i].CliNome = ds.Tables[0].Rows[i]["CLI_NOME"].ToString();
                            arrayObjGetCha[i].AplNome = ds.Tables[0].Rows[i]["APL_NOME"].ToString();
                            arrayObjGetCha[i].ChaPrazo = ds.Tables[0].Rows[0]["CHA_PRAZO"].ToString();
                            arrayObjGetCha[i].AnlNome = ds.Tables[0].Rows[i]["ANL_NOME"].ToString();
                            arrayObjGetCha[i].ChaDescricao = ds.Tables[0].Rows[i]["CHA_DESCRICAO"].ToString();
                            arrayObjGetCha[i].ChaTitulo = ds.Tables[0].Rows[i]["CHA_TITULO"].ToString();

                        }


                }
                return arrayObjGetCha;
            }
        }
        }
    }

