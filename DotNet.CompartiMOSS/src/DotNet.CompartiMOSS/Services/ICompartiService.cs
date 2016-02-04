using DotNet.CompartiMOSS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CompartiMOSS.Services
{
    public interface ICompartiService
    {
        Task<List<Revista>> SearchNumbers();
        Task<List<Autor>> SearchAuthors();
        Task<List<Articulos>> SearchArticles(string number);
        Task<List<Articulos>> SearchArticlesByAutor(string autor);
    }
}
