using DotNet.CompartiMOSS.Models;
using System.Collections.Generic;

namespace DotNet.CompartiMOSS.Services
{
    public interface IArticulos
    {
        IEnumerable<Articulos> GetArticulosByAutor(string autor);
        IEnumerable<Articulos> GetArticulosByRevista(string revista);
    }
}
