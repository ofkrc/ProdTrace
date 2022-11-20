using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdTrace.Models.Classes;

namespace ProdTrace.Controllers
{
    public class SalesMovementController : Controller
    {
        // GET: SalesMovement
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SalesMovements.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSales()
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName +" "+x.CustomerSurname,
                                               Value = x.CustomerId.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName +" "+ x.StaffSurname,
                                               Value = x.StaffId.ToString()
                                           }).ToList();           
            ViewBag.dgr1 = value1;
            ViewBag.dgr2 = value2;
            ViewBag.dgr3 = value3;
            return View();
        }

        [HttpPost]
        public ActionResult AddSales(SalesMovement salesMovement)
        {
            salesMovement.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(salesMovement);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetSales(int id)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerId.ToString()
                                           }).ToList();
            List<SelectListItem> value3 = (from x in c.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StaffSurname,
                                               Value = x.StaffId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = value1;
            ViewBag.dgr2 = value2;
            ViewBag.dgr3 = value3;
            var value = c.SalesMovements.Find(id);
            return View("GetSales", value);
        }

        public ActionResult UpdateSales (SalesMovement salesMovement)
        {
            var value = c.SalesMovements.Find(salesMovement.SalesId);
            value.CustomerId = salesMovement.CustomerId;
            value.Piece = salesMovement.Piece;
            value.Price = salesMovement.Price;
            value.StaffId = salesMovement.StaffId;
            value.Date = salesMovement.Date;
            value.TotalPrice = salesMovement.TotalPrice;
            value.ProductId = salesMovement.ProductId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SalesDetail(int id)
        {
            var values = c.SalesMovements.Where(x => x.SalesId == id).ToList();
            return View(values);
        }
    }
}