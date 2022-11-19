using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProdTrace.Models.Classes;
namespace ProdTrace.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.Departments.Where(x => x.Status == true).ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var value = c.Departments.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDepartment(int id)
        {
            var value = c.Departments.Find(id);
            return View("GetDepartment", value);
        }

        public ActionResult UpdateDepartment(Department department)
        {
            var value = c.Departments.Find(department.DepartmentId);
            value.DepartmentName = department.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetail(int id)
        {
            var value = c.Staffs.Where(x => x.DepartmentId == id).ToList();
            var departmanNameValue = c.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = departmanNameValue;
            return View(value);
        }

        public ActionResult DepartmentStaffSales(int id)
        {
            var values = c.SalesMovements.Where(x => x.StaffId == id).ToList();
            var dp = c.Staffs.Where(x => x.StaffId == id).Select(y => y.StaffName + " " + y.StaffSurname).FirstOrDefault();
            ViewBag.dp = dp;
            return View(values);
        }
    }
}