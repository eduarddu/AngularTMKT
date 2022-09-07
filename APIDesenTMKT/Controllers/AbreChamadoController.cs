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

    public class AbreChamadoController : ControllerBase
    {
        

        private readonly IConfiguration configuration;
        public AbreChamadoController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [DisableCors]

        [HttpPost]
        [Route("SetAbreChamado")]

        public string SetAbreChamado(Models.AbreChamado objAbreChamado, int ctrCodigo, string agtCodigo, int aplCodigo, int atcCodigo, string descricao, string titulo)
        {
            DataSet ds = new DataSet();
            DAL.AbreChamadoDAL dalAbreChamado = new DAL.AbreChamadoDAL(this.configuration);

            try
            {
                dalAbreChamado.SetAbreChamado(objAbreChamado, ctrCodigo, agtCodigo, aplCodigo, atcCodigo, descricao, titulo);
            }

            catch (Exception ex)
            {
                return "erro";
            }
            return "ok";
        }
    }



}