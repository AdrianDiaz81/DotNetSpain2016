using Microsoft.AspNet.Mvc;
using DotNet.CompartiMOSS.Services;

namespace DotNet.CompartiMOSS.Controllers
{
    public class HomeController : Controller
    {
        private IPartner _service;

        public HomeController(IPartner service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var partnerCollection = _service.GetPartners();
            return View(partnerCollection);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
