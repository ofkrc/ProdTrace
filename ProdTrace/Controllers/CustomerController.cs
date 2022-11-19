using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdTrace.Models.Classes;

namespace ProdTrace.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Customers.Where(x => x.Status == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            customer.Status = true;
            c.Customers.Add(customer);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var value = c.Customers.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int id)
        {
            var value = c.Customers.Find(id);
            return View("GetCustomer", value);
        }

       public ActionResult UpdateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCustomer");
            }
            var value = c.Customers.Find(customer.CustomerId);
            value.CustomerName = customer.CustomerName;
            value.CustomerSurname = customer.CustomerSurname;
            value.CustomerCountry = customer.CustomerCountry;
            value.CustomerMail = customer.CustomerMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerSalesHistory(int id)
        {
            var values = c.SalesMovements.Where(x => x.CustomerId == id).ToList();
            var ViewBagValue = c.Customers.Where(x => x.CustomerId == id).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.customer = ViewBagValue;
            return View(values);
        }
    }
}