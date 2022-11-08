using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace APIDesenTMKT.Models
{
    public class FileModel
    {
        public IFormFile MyFile { get; set; }
        public string AlText { get; set; }

        public string Description { get; set; }
    }
}
