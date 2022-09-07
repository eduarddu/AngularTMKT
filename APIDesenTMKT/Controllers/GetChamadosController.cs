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

namespace APIDesenTMKT.Controllers
{
    public class GetChamadosController: ControllerBase
    {
        private readonly IConfiguration configuration;
        public GetChamadosController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("GetChamado")]

        public List<GetChamado> GetChamado(bool atribuido)
        {
            List<GetChamado> getChamado = new List<GetChamado>();
            DAL.GetChamadoDAL dal = new DAL.GetChamadoDAL(this.configuration);
            getChamado = dal.GetChamado(atribuido);
            return getChamado;
        }
    }

    

   public class GetEncerraChamadoController: ControllerBase
    {
        private readonly IConfiguration configuration;
        public GetEncerraChamadoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("GetEncerraChamado")]

        public List<EncerraChamado> GetEncerraChamado(string usuario)
        {
            List<EncerraChamado> getEncerra = new List<EncerraChamado>();
            DAL.EncherraChamadoDAL dal = new DAL.EncherraChamadoDAL(this.configuration);
            getEncerra = dal.GetEncerraChamado(usuario);
            return getEncerra;

        }
    }
}
