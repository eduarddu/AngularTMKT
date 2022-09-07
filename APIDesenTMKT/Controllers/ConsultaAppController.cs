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

    public class ConsultaAppController: ControllerBase
    {
        private readonly IConfiguration configuration;

        public ConsultaAppController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("GetConsultaApp")]

        public List<ConsultaApp> GetConsultaApp()
        {
            List<ConsultaApp> consulta = new List<ConsultaApp>();
            DAL.ConsultaAppDAL dal = new DAL.ConsultaAppDAL(this.configuration);
            consulta = dal.GetConsultaApp();
            return consulta;
        }
    }
}
