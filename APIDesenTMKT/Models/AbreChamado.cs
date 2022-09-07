using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDesenTMKT.Models;


namespace APIDesenTMKT.Models
{
    public class AbreChamado
    {
        //PARÂMETROS
        public int CtrCodigo { get; set; }
        public string AgtCodigo { get; set; }
        public int AplCodigo { get; set; }
        public int AtcCodigo { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
       
    }
}
