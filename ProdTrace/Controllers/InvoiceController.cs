using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdTrace.Models.Classes;

namespace ProdTrace.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Invoices.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            c.Invoices.Add(invoice);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetInvoice(int id)
        {
            var value = c.Invoices.Find(id);
            return View("GetInvoice", value);
        }

        public ActionResult UpdateInvoice(Invoice invoice)
        {
            var values = c.Invoices.Find(invoice.InvoiceId);
            values.InvoiceSerialNo = invoice.InvoiceSerialNo;
            values.InvoiceSequenceNo = invoice.InvoiceSequenceNo;
            values.InvoiceDate = invoice.InvoiceDate;
            values.InvoiceHour = invoice.InvoiceHour;
            values.DeliveryFrom = invoice.DeliveryFrom;
            values.DeliveryTo = invoice.DeliveryTo;
            values.InvoiceTaxAuthority = invoice.InvoiceTaxAuthority;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetail(int id)
        {
            var value = c.InvoiceColumns.Where(x => x.InvoiceId== id).ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddInvoiceColumn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoiceColumn(InvoiceColumn invoiceColumn)
        {
            c.InvoiceColumns.Add(invoiceColumn);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}