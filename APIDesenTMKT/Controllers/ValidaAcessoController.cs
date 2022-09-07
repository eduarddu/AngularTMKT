using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using APIDesenTMKT.Models;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.Net.Http.Formatting;
using Microsoft.AspNetCore.Cors;

namespace APIDesenTMKT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidaAcessoController: ControllerBase
    {
        private readonly IConfiguration configuration;
        public ValidaAcessoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        

        [HttpGet]
        [Route("SetValidaAcesso")]

        public List<ValidaAcesso> GetValidaAcesso(string matricula, string senha)
        {
            List<ValidaAcesso> acesso = new List<ValidaAcesso>();
            DAL.ValidaAcessoDAL dal = new DAL.ValidaAcessoDAL(this.configuration);
            acesso = dal.GetValidaAcesso(matricula, senha);
            return acesso;
        }

        }

    }

