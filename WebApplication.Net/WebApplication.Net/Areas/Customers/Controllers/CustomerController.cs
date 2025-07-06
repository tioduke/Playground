using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using WebApplication.Net.Customers.Models;

namespace WebApplication.Net.Customers.Controllers
{
    [Area("Customers")]
    public class CustomerController : Controller
    {
        private readonly IUrlHelper _urlHelper;
        private List<Customer> Customers = new List<Customer>();

        public CustomerController(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;

            Customer obj1 = new Customer();
            obj1.Id = 12;
            obj1.CustomerCode = "1001";
            obj1.CustomerName = "Asterix";
            obj1.NAS = "046454286";
            obj1.Amount = 90.34M;
            obj1.BirthDate = new DateTime(1008, 11, 01);
            Customers.Add(obj1);

            obj1 = new Customer();
            obj1.Id = 11;
            obj1.CustomerCode = "1002";
            obj1.CustomerName = "Obelix";
            obj1.NAS = "046454286";
            obj1.Amount = 91.00M;
            obj1.BirthDate = new DateTime(972, 10, 05);
            Customers.Add(obj1);

            obj1 = new Customer();
            obj1.Id = 0;
            obj1.CustomerCode = "0000";
            obj1.NAS = "000000000";
            obj1.CustomerName = String.Empty;
            obj1.Amount = 0.00M;
            obj1.BirthDate = new DateTime(1, 1, 1);
            Customers.Add(obj1);
        }

        // GET: /Customers/Customer/Index
        public ActionResult Index()
        {
            return View("CustomerForm");
        }

        // POST: /Customers/Customer/DisplayCustomer
        [HttpPost]
        public ActionResult DisplayCustomer(Customer obj)
        {
            if (ModelState.IsValid)
            {
                obj.CustomerUrl = _urlHelper.Action("DisplayCustomer", "Customers", new { area = "Customer" });
                return View("DisplayCustomer", obj);
            }
            else
            {
                ModelState.AddModelError("Customer Form", "There are errors in the form, please correct.");
                return View("CustomerForm", obj);
            }
        }

        // GET: /Customers/Customer/DisplayCustomer
        public ActionResult DisplayCustomer(int id)
        {
            Customer objCustomer = Customers.Find(x => x.Id == id);
            if (objCustomer == null) objCustomer = Customers.Find(x => x.Id == 0);

            objCustomer.CustomerUrl = _urlHelper.Action("DisplayCustomer", "Customers", new { area = "Customer" });
            return DisplayCustomer(objCustomer);
        }

        // GET: /Customers/Customer/IsAmountValide
        public JsonResult IsAmountValide(Customer obj)
        {
            return (obj.NAS == null || obj.Amount > 0.0m)
                ? Json(true/*, JsonRequestBehavior.AllowGet*/)
                : Json(false/*, JsonRequestBehavior.AllowGet*/);
        }
    }
}
