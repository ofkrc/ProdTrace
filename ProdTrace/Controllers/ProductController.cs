using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdTrace.Models.Classes;

namespace ProdTrace.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var products = c.Products.Where(x => x.Status == true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.value1 = values;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            c.Products.Add(product);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var value = c.Products.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.value1 = values;
            var value = c.Products.Find(id);
            return View("GetProduct", value);
        }

        public ActionResult UpdateProduct(Product p)
        {
            var value = c.Products.Find(p.ProductId);
            value.ProductImage = p.ProductImage;
            value.ProductName = p.ProductName;
            value.PurchasePrice = p.PurchasePrice;
            value.SalesPrice = p.SalesPrice;
            value.Stock = p.Stock;
            value.Brand = p.Brand;
            value.Status = p.Status;
            value.CategoryId = p.CategoryId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var value = c.Products.ToList();
            return View(value);
        }
    }
}