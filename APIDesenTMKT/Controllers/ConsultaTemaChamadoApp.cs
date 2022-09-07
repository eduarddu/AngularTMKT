using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using APIDesenTMKT.Models;
using System.Linq;
using System.Threading.Tasks;

namespace APIDesenTMKT.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class ConsultaTemaChamadoAppController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ConsultaTemaChamadoAppController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("GetConsultaTemaChamadoApp")]

        public List<ConsultaTemaChamadoApp> GetConsultaTemaChamadoApp(int AplCodigo)
        {
            List<ConsultaTemaChamadoApp> tema = new List<ConsultaTemaChamadoApp>();
            DAL.ConsultaTemaChamadoAppDAL dal = new DAL.ConsultaTemaChamadoAppDAL(this.configuration);
            tema = dal.GetConsultaTemaChamadoApp(AplCodigo);
            return tema;
        }

    }
}