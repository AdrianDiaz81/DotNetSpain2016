
using DotNet.CompartiMOSS.Models;
using System.Collections.Generic;

namespace DotNet.CompartiMOSS.Services
{
    public interface IRevista
    {
        Revista GetLastNumber();

        IEnumerable<Revista> GetRevistas();
        Revista GetRevistaByTitle(string name);
    }
}
