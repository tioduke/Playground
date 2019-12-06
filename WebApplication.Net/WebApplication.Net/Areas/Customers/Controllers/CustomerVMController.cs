using Microsoft.AspNetCore.Mvc;

using WebApplication.Net.Customers.Models;

namespace WebApplication.Net.Customers.Controllers
{
    [Area("Customers")]
    public class CustomerVMController : Controller
    {
        //
        // GET: /Customers/Customer/DisplayCustomer
        public ActionResult DisplayCustomer()
        {
            CustomerViewModel obj = new CustomerViewModel();
            obj.TxtName = "Panoramix";
            obj.TxtAmount = "1000";
            return View(obj);
        }
    }
}