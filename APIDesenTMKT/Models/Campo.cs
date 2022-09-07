using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDesenTMKT.Models
{
    public class Campo
    {
        public String Matricula { get; set; }
        public String Descricao { get; set; }
        public bool Visualizar { get; set; }
        public bool Habilitar { get; set; }
        public Campo() { }
    }
}
