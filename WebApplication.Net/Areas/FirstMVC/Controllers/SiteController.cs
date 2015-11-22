using Microsoft.AspNet.Mvc;

namespace WebApplication.Net.FirstMVC.Controllers
{
    [Area("FirstMVC")]
    public class SiteController : Controller
    {
        //
        // GET: /FirstMVC/Site/GotoHome
        public ActionResult GotoHome()
        {
            return View("Home");
        }

        // GET: /FirstMVC/Site/AboutUs
        public ActionResult AboutUs()
        {
            return View("About");
        }

        // GET: /FirstMVC/Site/SeeProduct
        public ActionResult SeeProduct()
        {
            return View("Product");
        }
    }
}