using Microsoft.AspNetCore.Mvc;

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