using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Net.FirstMVC.Controllers
{
    [Area("FirstMVC")]
    public class Default1Controller : Controller
    {
        //
        // GET: /FirstMVC/Default1/Action1
        public ActionResult Action1()
        {
            HttpContext.Session.SetString("Session1", "UntilBrowserCloses");
            TempData["FortheFullRequest"] = "FortheFullRequest";
            ViewData["Myval"] = "ControllertoView";
            ViewBag.MyVal = "ControllertoView";
            return RedirectToAction("SomeOtherAction", "Default2");
        }
    }
}