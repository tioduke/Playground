using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Net.FirstMVC.Controllers
{
    [Area("FirstMVC")]
    public class DisplayTimeController : Controller
    {
        //
        // GET: /FirstMVC/DisplayTime/Index
        public ActionResult Index()
        {
            ViewData["CurrentTime"] = DateTime.Now.ToString();
            return View();
        }
    }
}