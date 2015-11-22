using Microsoft.AspNet.Mvc;

namespace WebApplication.Net.FirstMVC.Controllers
{
    [Area("FirstMVC")]
    public class SomeController : Controller
    {
        // GET: /FirstMVC/Some/MyView
        public ActionResult MyView()
        {
            return View();
        }
    }
}