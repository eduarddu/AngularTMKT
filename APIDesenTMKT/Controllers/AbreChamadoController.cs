using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using APIDesenTMKT.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace APIDesenTMKT.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AbreChamadoController : ControllerBase
    {

        private IWebHostEnvironment webHostEnvironment;
        private IHttpContextAccessor httpContextAccessor;


        private string FolderTemp = System.Configuration.ConfigurationSettings.AppSettings["FolderTempAnexo"];
        private string FolderChamado = System.Configuration.ConfigurationSettings.AppSettings["FolderAnexo"];
        
        private readonly IConfiguration configuration;


        public AbreChamadoController(IConfiguration configuration, IWebHostEnvironment _webHostEnvironment, IHttpContextAccessor _httpContextAccessor) 
        {
            this.configuration = configuration;
            webHostEnvironment = _webHostEnvironment;
            httpContextAccessor = _httpContextAccessor;
        }


        [HttpPost]
        [Route("SetAbreChamado")]

        
        


        public  string AbreChamado(IFormFile file, int ctrCodigo, string agtCodigo, int aplCodigo, int atcCodigo, string descricao, string titulo)
        {
            
            int chaCodigo;
            DataSet ds = new DataSet();
            DAL.AbreChamadoDAL dalAbreChamado = new DAL.AbreChamadoDAL(this.configuration);




            try
            {

                chaCodigo = dalAbreChamado.SetAbreChamado(ctrCodigo, agtCodigo, aplCodigo, atcCodigo, descricao, titulo);


                var path = Path.Combine(webHostEnvironment.WebRootPath, "TempAberturaChamados", file.FileName+chaCodigo);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                var baseURL = httpContextAccessor.HttpContext.Request.Scheme + "://" +
                httpContextAccessor.HttpContext.Request.Host +
                httpContextAccessor.HttpContext.Request.PathBase;

                ZipFile.CreateFromDirectory(
                 @"C:\Users\885089\Desktop\TesteCompactacao\"+chaCodigo+".zip",
                  @"C:\Users\885089\Desktop\teste\cu",

                 CompressionLevel.Fastest,
                true);

            }


            catch (Exception ex)
            {
                chaCodigo = -1;
                
            }

            return "Demanda " + chaCodigo + " aberto com a área de desenvolvimento e o file é "+file.FileName+chaCodigo;


          
           
       


        }

        


        


    }




    }
