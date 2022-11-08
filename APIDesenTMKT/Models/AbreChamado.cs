using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDesenTMKT.Controllers;
using APIDesenTMKT.Models;
using Microsoft.AspNetCore.Http;

namespace APIDesenTMKT.Models
{
    public class AbreChamado
    {
        //PARÂMETROS
       
        public int ctrCodigo { get; set; }
        public string agtCodigo { get; set; }
        public int aplCodigo { get; set; }
        public int atcCodigo { get; set; }
        public string descricao { get; set; }
        public string titulo { get; set; }
        public int chaCodigo { get; set; }
    }
}
