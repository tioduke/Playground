using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Net.FirstMVC.Controllers
{
    [Area("FirstMVC")]
    public class Default2Controller : Controller
    {
        //
        // GET: /FirstMVC/Default2/SomeOtherAction
        public ActionResult SomeOtherAction()
        {
            string str = Convert.ToString(TempData["FortheFullRequest"]);
            string str2 = HttpContext.Session.GetString("Session1");
            string str3 = Convert.ToString(ViewData["Myval"]);
            string str4 = ViewBag.MyVal;
            ViewData["Myval"] = "ControllertoView";
            ViewBag.MyVal = "ControllertoViewCollection";
            return View("SomeView");
        }
    }
}