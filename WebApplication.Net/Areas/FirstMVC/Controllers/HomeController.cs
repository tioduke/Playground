using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Net.FirstMVC.Controllers
{
    [Area("FirstMVC")]
    public class HomeController : Controller
    {
        //
        // GET: /FirstMVC/Home/Index
        public ActionResult Index()
        {
            return View("HelloView");
        }

        // GET: /FirstMVC/Home/DisplayPdf
        public ActionResult DisplayPdf()
        {
            //return View("EmbedViewer);
            return View("DocViewer");
            //return View("PageViewer");
        }

        // GET: /FirstMVC/Home/GetPdf
        public FileStreamResult GetPdf()
        {
            FileStream fs = new FileStream("/home/sergio/Documents/datarecovery.pdf", FileMode.Open, FileAccess.Read);
            return File(fs, "application/pdf");
        }
    }
}