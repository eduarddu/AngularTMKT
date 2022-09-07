using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDesenTMKT.Models;


namespace APIDesenTMKT.Models
{
    public class ValidaAcesso
    {
        //PARÂMETROS
        public string Matricula { get; set; }
        public string Senha { get; set; }

        public string TokenFunc { get; set; }

        //COLUNAS
        public string Nome { get; set; }
        public string NomeAbrev { get; set; }
        public string Email { get; set; }
        public int CtrCodigo { get; set; }
        public string CtrDescricao { get; set; }
        public string CgoDescricao { get; set; }

        public bool AcessoVal = false;
        public string MsgAcesso { get; set; }

        

      

    }
}
