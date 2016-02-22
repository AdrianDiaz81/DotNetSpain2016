using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.CompartiMOSS.Model
{
    public class Revista
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string UrlPortada { get; set; }
        public string Editorial { get; set; }
        public string UrlPDF { get; set; }
        public string Numero { get; set; }
    }
}
