
using DotNet.CompartiMOSS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CompartiMOSS.Services
{
    public interface IRevista
    {
        Task<Revista> GetLastNumber();

        Task<IEnumerable<Revista>> GetRevistas();
        Task<Revista> GetRevistaByTitle(string name);
    }
}
