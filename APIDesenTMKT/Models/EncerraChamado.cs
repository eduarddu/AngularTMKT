using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDesenTMKT.Models;


namespace APIDesenTMKT.Models
{
    public class EncerraChamado
    {
        //PARÂMETROS
        public string Usuario  {get; set;}

        //COLUNAS
        public int ChaCodigo { get; set; }
        public DateTime ChaDataAbertura { get; set; }
        public string ChaSolicitante { get; set; }
        public string TpcDescricao { get; set; }
        public string CliNome { get; set; }
        public string AplNome { get; set; }
        public string AnlNome { get; set; }
        public string ChaDescricao { get; set; }
        public DateTime ChaDataEncerramento { get; set; }
        public string ChaTitulo { get; set; }


    }
}
