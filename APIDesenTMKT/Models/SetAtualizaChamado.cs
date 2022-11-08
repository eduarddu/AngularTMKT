using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDesenTMKT.Models;

namespace APIDesenTMKT.Models
{
    public class SetAtualizaChamado
    {
        //PARÂMETROS
        public int ChaCodigo { get; set; }
        public string Status { get; set; }
        public string AgtCodigo { get; set; }
        public DateTime Prazo {get; set;}
    }
}
