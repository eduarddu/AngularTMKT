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
using System.Configuration;
using System.Text;
using System.Net;


namespace APIDesenTMKT.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AbreChamadoController : ControllerBase
    {

        private IWebHostEnvironment webHostEnvironment;
        private IHttpContextAccessor httpContextAccessor;


        private string FolderTemp = System.Configuration.ConfigurationSettings.AppSettings["FolderTempAnexo"];
        string FolderChamado = System.Configuration.ConfigurationSettings.AppSettings["FolderAnexo"];

        string urlArquivo = "http://www.devmedia.com.br/imagens/portal2010/logo-devmedia.png";
        string caminhoArquivo = @"C:\Users\885089\Desktop\test";

        private readonly IConfiguration configuration;


        public AbreChamadoController(IConfiguration configuration, IWebHostEnvironment env, IHttpContextAccessor _httpContextAccessor)
        {
            this.configuration = configuration;
            webHostEnvironment = env;
            
        }
        [HttpPost]
        [Route("SetAbreChamado")]
       
        public string AbreChamado(IFormFile file, int ctrCodigo, string agtCodigo, int aplCodigo, int atcCodigo, string descricao, string titulo)
        {

            int chaCodigo;
            DataSet ds = new DataSet();
            DAL.AbreChamadoDAL dalAbreChamado = new DAL.AbreChamadoDAL(this.configuration);


            try
            {

                chaCodigo = dalAbreChamado.SetAbreChamado(ctrCodigo, agtCodigo, aplCodigo, atcCodigo, descricao, titulo);
                


                var path = Path.Combine(webHostEnvironment.WebRootPath, carregarArquivo(chaCodigo), file.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

               

                //var baseURL = httpContextAccessor.HttpContext.Request.Scheme + "://" +
                //httpContextAccessor.HttpContext.Request.Host +
                // httpContextAccessor.HttpContext.Request.PathBase;  
            }
             
            catch (Exception ex)
            {
                chaCodigo = -1;
            }


            //download(chaCodigo);
            return "Demanda " + chaCodigo + " aberto com a área de desenvolvimento e o file é " + file.FileName + chaCodigo;

        }


        [HttpPost]
        [Route("carregaArquivo")]
        public string carregarArquivo(int chaCodigo)
        {
            string caminho = @"\\tmkt-zl-wa06\SIC\AnexosChamados\" + @"\" + chaCodigo.ToString() + @"\"; ;
            string caminho2 = FolderChamado + @"\" + chaCodigo.ToString() + @"\"; 

            Directory.CreateDirectory(caminho);
                return caminho;
        }

        [HttpGet("download")]
       
        public IActionResult download(int chaCodigo)
        {
            var (fileType, bytes,fileName) = new AbreChamado(webHostEnvironment).DowloadZip(@"\\tmkt-zl-wa06\SIC\AnexosChamados\"+chaCodigo);
            return  File(bytes, fileType, fileName);
        }

        
    }


}