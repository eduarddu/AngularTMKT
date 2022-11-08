using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using APIDesenTMKT.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace APIDesenTMKT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetAtualizaChamadoController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public SetAtualizaChamadoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("SetAtualizaChamado")]

        public void SetAtualizaChamado(int chacodigo, string status, string agtcodigo, DateTime prazo)
        {
            Models.SetAtualizaChamado objAtu = new Models.SetAtualizaChamado();
            DAL.SetAtualizaChamadoDAL dados = new DAL.SetAtualizaChamadoDAL(configuration);

            try
            {
                objAtu.ChaCodigo = chacodigo;
                objAtu.Status = status;
                objAtu.AgtCodigo = agtcodigo;
                objAtu.Prazo = prazo;
                dados.SetAtualizaChamado(objAtu);
                

            }

            catch (Exception ex)
            {
                string a = "ERRO!!!";
            }
        }
        
    }
}
