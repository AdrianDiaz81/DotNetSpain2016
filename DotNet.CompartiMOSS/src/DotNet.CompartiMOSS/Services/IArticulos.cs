using DotNet.CompartiMOSS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CompartiMOSS.Services
{
    public interface IArticulos
    {
        Task<IEnumerable<Articulos>> GetArticulosByAutor(string autor);
        Task<IEnumerable<Articulos>> GetArticulosByRevista(string revista);
    }
}
