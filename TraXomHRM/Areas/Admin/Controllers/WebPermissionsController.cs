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

namespace TraXomHRM.Areas.Admin.Controllers
{
    public class WebPermissionsController : Controller
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/WebPermissions
        public ActionResult Index()
        {
            var permission = db.Permissions.Include(w => w.WebBusiness);
            return View(permission.ToList());
        }

        // GET: Admin/WebPermissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.DataModel.WebPermission webPermission = db.Permissions.Find(id);
            if (webPermission == null)
            {
                return HttpNotFound();
            }
            return View(webPermission);
        }

        // GET: Admin/WebPermissions/Create
        public ActionResult Create()
        {
            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName");
            return View();
        }

        // POST: Admin/WebPermissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissionId,PermissionName,Description,BusinessId")] Models.DataModel.WebPermission webPermission)
        {
            if (ModelState.IsValid)
            {
                db.Permissions.Add(webPermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName", webPermission.BusinessId);
            return View(webPermission);
        }

        // GET: Admin/WebPermissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.DataModel.WebPermission webPermission = db.Permissions.Find(id);
            if (webPermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName", webPermission.BusinessId);
            return View(webPermission);
        }

        // POST: Admin/WebPermissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissionId,PermissionName,Description,BusinessId")] Models.DataModel.WebPermission webPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webPermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "BusinessId", "BusinessName", webPermission.BusinessId);
            return View(webPermission);
        }

        // GET: Admin/WebPermissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.DataModel.WebPermission webPermission = db.Permissions.Find(id);
            if (webPermission == null)
            {
                return HttpNotFound();
            }
            return View(webPermission);
        }

        // POST: Admin/WebPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.DataModel.WebPermission webPermission = db.Permissions.Find(id);
            db.Permissions.Remove(webPermission);
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
