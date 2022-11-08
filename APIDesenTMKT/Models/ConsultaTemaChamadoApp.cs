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
        public int aplCodigo { get; set; }

        //COLUNAS
        public int atcCodigo { get; set; }
        public string atcDescricao { get; set; }
    }
}