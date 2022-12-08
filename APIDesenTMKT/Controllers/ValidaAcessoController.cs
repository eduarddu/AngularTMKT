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
    public class ValidaAcessoController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ValidaAcessoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("getValidaAcesso")]

        public List<ValidaAcesso> getValidaAcesso(string AgtCodigo, string Senha)
        {
            List<ValidaAcesso> resultado = new List<ValidaAcesso>();
            DAL.ValidaAcessoDAL dal = new DAL.ValidaAcessoDAL(this.configuration);
            resultado = dal.getValidaAcesso(AgtCodigo, Senha);
            return resultado;
        }

    }

}