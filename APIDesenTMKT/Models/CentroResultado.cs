using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDesenTMKT.Models;

namespace APIDesenTMKT.Models
{
    public class CentroResultado
    {
        //PARÂMETROS
        public int TipoBusca { get; set; }
        public string AgtCodigo { get; set; }
        public int VarCtrCodigo { get; set; }

        // COLUNAS

        public int CtrCodigo { get; set; }
        public string CtrDescricao { get; set; }
    }
}