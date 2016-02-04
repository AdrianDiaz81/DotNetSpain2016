using System.Collections.Generic;
using DotNet.CompartiMOSS.Models;

namespace DotNet.CompartiMOSS.Services
{
    public interface IPartner 
    {
        IEnumerable<Partner> GetPartners();

    }
}
