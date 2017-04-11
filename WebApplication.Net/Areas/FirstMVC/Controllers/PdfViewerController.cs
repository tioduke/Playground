using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Net.FirstMVC.Controllers
{
    [Area("FirstMVC")]
    public class PdfViewerController : Controller
    {

        // GET: /FirstMVC/PdfViewer/DisplayPdf
        public ActionResult DisplayPdf(int? id)
        {
            if (id == null || id.Value == 0) {
                return View("DocViewer");
            } else if (id.Value == 1) {
                return View("PageViewer");
            } else if (id.Value == 2) {
                return View("EmbedViewer");
            } else {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return new EmptyResult();
            }
        }

        // GET: /FirstMVC/PdfViewer/GetPdf
        public FileStreamResult GetPdf()
        {
            FileStream fs = new FileStream("/home/sergio/Documents/datarecovery.pdf", FileMode.Open, FileAccess.Read);
            return File(fs, "application/pdf");
        }

        // GET: /FirstMVC/PdfViewer/DownloadPdf
        public FileStreamResult DownloadPdf()
        {
            Response.Headers["Content-Disposition"] = "attachment; filename=datarecovery.pdf";
            FileStream fs = new FileStream("/home/sergio/Documents/datarecovery.pdf", FileMode.Open, FileAccess.Read);
            return File(fs, "application/pdf");
        }
    }
}