using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using APIDesenTMKT.Models;

namespace APIDesenTMKT.Controllers
{
    [Route("api/demoUpdate")]
    public class UploadController : Controller
    {

        private IWebHostEnvironment webHostEnvironment;
        private IHttpContextAccessor httpContextAccessor;
        public UploadController(IWebHostEnvironment _webHostEnvironment, IHttpContextAccessor _httpContextAccessor)
        {
            webHostEnvironment = _webHostEnvironment;
            httpContextAccessor = _httpContextAccessor;
        }

        [Produces("application/json")]
        [HttpPost("uploads")]
        public IActionResult Uploads(int chaCodigo,IFormFile file)
        {


            try
            {


                var path = Path.Combine(webHostEnvironment.WebRootPath, "TempAberturaChamados", file.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                var baseURL = httpContextAccessor.HttpContext.Request.Scheme + "://" +
                httpContextAccessor.HttpContext.Request.Host +
                httpContextAccessor.HttpContext.Request.PathBase;

                return Ok(new
                {
                    fileName = baseURL + "/TempAberturaChamados/" + file.FileName,
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
