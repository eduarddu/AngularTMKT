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

    public class DesenvolvedorController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public DesenvolvedorController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("GetConsultaDEV")]

        public List<Desenvolvedor> GetConsultaApp()
        {
            List<Desenvolvedor> consultaDev = new List<Desenvolvedor>();
            DAL.DesenvolvedorDAL dal = new DAL.DesenvolvedorDAL(this.configuration);
            consultaDev = dal.GetConsultaDev();
            return consultaDev;
        }
    }
}
