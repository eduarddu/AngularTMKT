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
    public class EncerraChamadoController : Controller
    {
        private readonly IConfiguration configuration;
        public EncerraChamadoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("SetEncerraChamado")]

        public string SetEncerraChamado(Models.EncerraChamado objEncerraCha, int chacodigo, string status)
        {
            DataSet ds = new DataSet();
            DAL.EncerraChamado dalEncerraCha = new DAL.EncerraChamado(this.configuration);

            try
            {
                dalEncerraCha.setEncerraChamado(objEncerraCha, chacodigo, status);
            }
            catch(Exception ex)
            {
                return "erro";
            }
            return "ok";
        }
    }
}
