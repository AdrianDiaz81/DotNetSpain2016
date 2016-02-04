using System.Collections.Generic;
using DotNet.CompartiMOSS.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.CompartiMOSS.Services
{
    public class ArticuloService : IArticulos
    {
        private IEnumerable<Articulos> _repository;

        public ArticuloService()
        {
            _repository = new Articulos[] 
            {
                new Articulos { Autor="Adrián Díaz", NumeroRevista="Número 16", Texto="....", Titulo="Uso de Frameworks JavaScript en desarrollos SharePoint - Parte I" },
                new Articulos { Autor="Adrián Díaz", NumeroRevista="Número 17", Texto="....", Titulo="Uso de Frameworks JavaScript en desarrollos SharePoint - Parte II" } ,
                new Articulos { Autor="Adrián Díaz", NumeroRevista="Número 18", Texto="....", Titulo="Introducción al desarrollo para Yammer" },
                new Articulos {Autor="Juan Carlos Gonzales Martin", NumeroRevista="Número 26 - Diciembre 2016",Texto="",Titulo="Escenarios de uso de PowerShell para shaerPoint" }
            };
        }
        public async Task<IEnumerable<Articulos>> GetArticulosByAutor(string autor)
        {
            var compartimossService = new CompartiService();
            _repository = await compartimossService.SearchArticlesByAutor(autor);
            return _repository;
        }

        public async Task<IEnumerable<Articulos>> GetArticulosByRevista(string revista)
        {
            var compartimossService = new CompartiService();
            _repository = await compartimossService.SearchArticles(revista);
            return _repository.Where(x=>x.NumeroRevista.Equals(revista));
        }
    }
}
