using System;
using System.IO;
using System.Text;

namespace APIDesenTMKT.Controllers
{
    public class teste
    {

        public void carregaArquivo(int chaCodigo)
        {
            string caminho = @"C:\Users\885089\Desktop\APIDesenTMKT\APIDesenTMKT\wwwroot\TempAberturaChamados\" + chaCodigo


            using (FileStream fs = File.Create(caminho)) ;

        }

        
    }
}
