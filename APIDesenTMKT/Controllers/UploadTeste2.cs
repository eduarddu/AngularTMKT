using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using APIDesenTMKT.Models;
using Microsoft.Extensions.Configuration;

namespace APIDesenTMKT.Controllers
{
    [Route("api/TesteUpdate2")]
    public class UploadTeste2 : Controller
    {



        private readonly IConfiguration configuration;
        public UploadTeste2(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        private IWebHostEnvironment webHostEnvironment;
        private IHttpContextAccessor httpContextAccessor;
        public UploadTeste2(IWebHostEnvironment _webHostEnvironment, IHttpContextAccessor _httpContextAccessor)
        {
            webHostEnvironment = _webHostEnvironment;
            httpContextAccessor = _httpContextAccessor;
        }

       

        [Produces("application/json")]
        [HttpPost("UploadTeste2")]
        public IActionResult Uploads2(IFormFile file, int chaCodigo)
        {



            

            try
            {


                var path = Path.Combine(webHostEnvironment.WebRootPath, "AnexosChamados", file.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }


                var baseURL = httpContextAccessor.HttpContext.Request.Scheme + "://" + chaCodigo + 
                httpContextAccessor.HttpContext.Request.Host +
                httpContextAccessor.HttpContext.Request.PathBase;

                return Ok(new
                {
                    fileName = baseURL + "/AnexosChamados/" + file.FileName + chaCodigo,
                    fileSize = file.Length

                });
            }

            catch
            {
                return BadRequest();
            }

        }
    }
}

