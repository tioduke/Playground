using System;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;

using WebApplication.Net.Customers.Models;

namespace WebApplication.Net.Customers.Controllers
{
    [Area("Customers")]
    public class JsonController : Controller
    {
        //
        // GET: /Customers/Json/DisplayJson
        public ActionResult DisplayJson()
        {
            return View("LearnJquery");
        }

        // GET: /Customers/Json/getJson
        public JsonResult getJson()
        {
            Customer obj = new Customer();
            obj.CustomerCode = "c001";
            return Json(obj/*, JsonRequestBehavior.AllowGet*/);
        }

        // GET: /Customers/Json/Index
        public ActionResult Index()
        {
            Customer obj = new Customer();
            obj.Id = 12;
            obj.CustomerCode = "1001";
            obj.CustomerName = "Asterix";
            obj.NAS = "046454286";
            obj.Amount = 90.34M;
            obj.BirthDate = new DateTime(1008, 11, 01);

            return View(obj);
        }

        // GET: /Customers/Json/sendJson
        public ActionResult sendJson()
        {
            Customer obj = JsonConvert.DeserializeObject<Customer>(Request.Form["customer"]);
            obj.CustomerName += " (modified)";
            
            return PartialView("_Popup", obj);
        }

        // GET: /Customers/Json/ItsAPopup
        public ActionResult ItsAPopup()
        {
            Customer obj = new Customer();
            obj.Id = 12;
            obj.CustomerCode = "1001";
            obj.CustomerName = "Asterix";
            obj.NAS = "046454286";
            obj.Amount = 90.34M;
            obj.BirthDate = new DateTime(1008, 11, 01);

            return PartialView("_Popup", obj);
        }
    }
}