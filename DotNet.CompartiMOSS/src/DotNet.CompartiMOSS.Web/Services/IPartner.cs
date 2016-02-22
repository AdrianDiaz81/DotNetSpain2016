using DotNet.CompartiMOSS.Model;
using System.Collections.Generic;

namespace DotNet.CompartiMOSS.Services
{
    public interface IPartner 
    {
        IEnumerable<Partner> GetPartners();

    }
}
