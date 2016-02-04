using DotNet.CompartiMOSS.Models;
using System.Collections.Generic;

namespace DotNet.CompartiMOSS.Services
{
   public interface IAutor
    {
        IEnumerable<Autor> GetAllAutor();
        Autor GetAutorByName(string name);
    }
}
