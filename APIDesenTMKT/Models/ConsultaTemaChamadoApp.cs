using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDesenTMKT.Models;

namespace APIDesenTMKT.Models
{
    public class ConsultaTemaChamadoApp
    {
        //PARÂMETRO
        public int AplCodigo { get; set; }

        //COLUNAS
        public int AtcCodigo { get; set; }
        public string AtcDescricao { get; set; }
    }
}