using DotNet.CompartiMOSS.Services;
using Microsoft.AspNet.Mvc;

namespace DotNet.CompartiMOSS.ViewComponents
{
    public class Partner:ViewComponent
    {
        private IPartner _service;
        public Partner(IPartner service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var partners = _service.GetPartners();
            return View(partners);
        }
    }
}
