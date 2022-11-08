using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDesenTMKT.Models;

namespace APIDesenTMKT.Models
{
    public class GetChamado
    {
        //PARAMETROS
        public bool Atribuido { get; set; }

        //COLUNAS
        public int ChaCodigo { get; set; }
        public string ChaDataAbertura { get; set; } // Possivel conversão para string;
        public string ChaSolicitante { get; set; }
        public string TpcDescricao { get; set; }
        public string CliNome { get; set; }
        public string AplNome { get; set; }
        public string ChaPrazo { get; set; }
        public string AnlNome { get; set; }
        public string ChaDescricao { get; set; }
        public string ChaTitulo { get; set; }

    }
}
