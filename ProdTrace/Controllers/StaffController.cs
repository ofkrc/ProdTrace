using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdTrace.Models.Classes;

namespace ProdTrace.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Staffs.ToList();
            return View(values);
        }
        
        [HttpGet]
        public ActionResult AddStaff()
        {
            List<SelectListItem> values = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.value1 = values;
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Staff staff)
        {
            c.Staffs.Add(staff);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetStaff(int id)
        {
            List<SelectListItem> values = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.value1 = values;
            var value = c.Staffs.Find(id);
            return View("GetStaff", value);
        }

        public ActionResult UpdateStaff(Staff staff)
        {
            var value = c.Staffs.Find(staff.StaffId);
            value.StaffName = staff.StaffName;
            value.StaffSurname = staff.StaffSurname;
            value.StaffImage = staff.StaffImage;
            value.DepartmentId = staff.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}