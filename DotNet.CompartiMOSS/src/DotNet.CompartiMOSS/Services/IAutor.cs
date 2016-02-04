using DotNet.CompartiMOSS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CompartiMOSS.Services
{
   public interface IAutor
    {
       Task<IEnumerable<Autor>> GetAllAutor();
       Task<Autor> GetAutorByName(string name);
    }
}
