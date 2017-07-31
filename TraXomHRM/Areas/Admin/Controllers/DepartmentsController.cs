using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TraXomHRM.Areas.Admin.Models.BusinessModel;
using TraXomHRM.Areas.Admin.Models.DataModel;
using PagedList;

namespace TraXomHRM.Areas.Admin.Controllers
{
    public class DepartmentsController : Controller
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/Departments
        public ActionResult Index(string sortorder, string searchString, string currentFilter,int? page)
        {
            var departments = db.Departments.Include(d => d.Leader).Include(d => d.ParentDepartment);
            ViewBag.IdSortPara = String.IsNullOrEmpty(sortorder) ? "id_desc" : "";
            ViewBag.NameSortPara = sortorder == "name" ? "name_desc" : "name";
            if (!String.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(d => d.DepartmentName.ToUpper().Contains(searchString.ToUpper())
                || d.DepartmentId.ToString().Contains(searchString));
            }
            switch (sortorder)
            {
                case "name_desc": departments = departments.OrderByDescending(d => d.DepartmentName);
                    break;
                case "id_desc":
                    departments = departments.OrderByDescending(d => d.DepartmentId);
                    break;
                case "name":
                    departments = departments.OrderBy(d => d.DepartmentName);
                    break;
                default:departments = departments.OrderBy(d => d.DepartmentId);
                    break;
            }
            return View(departments.ToList());
        }

        // GET: Admin/Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Admin/Departments/Create
        public ActionResult Create()
        {
            ViewBag.LeaderId = new SelectList(db.Employees, "EmployeeId", "EmployeeCode");
            ViewBag.ParentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Admin/Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DepartmentName,ParentId,LeaderId")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeaderId = new SelectList(db.Employees, "EmployeeId", "EmployeeCode", department.LeaderId);
            ViewBag.ParentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", department.ParentId);
            return View(department);
        }

        // GET: Admin/Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeaderId = new SelectList(db.Employees, "EmployeeId", "EmployeeCode", department.LeaderId);
            ViewBag.ParentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", department.ParentId);
            return View(department);
        }

        // POST: Admin/Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,DepartmentName,ParentId,LeaderId")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeaderId = new SelectList(db.Employees, "EmployeeId", "EmployeeCode", department.LeaderId);
            ViewBag.ParentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", department.ParentId);
            return View(department);
        }

        // GET: Admin/Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Admin/Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
