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
    public class WebAdministratorsController : Controller
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/WebAdministrators
        public ActionResult Index()
        {
            return View(db.Administrators.ToList());
        }

        // GET: Admin/WebAdministrators/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebAdministrator webAdministrator = db.Administrators.Find(id);
            if (webAdministrator == null)
            {
                return HttpNotFound();
            }
            return View(webAdministrator);
        }

        // GET: Admin/WebAdministrators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/WebAdministrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password,FullName,Email,Avatar,IsAdmin,IsActive")] WebAdministrator webAdministrator)
        {
            if (ModelState.IsValid)
            {
                webAdministrator.Password = Common.EncryptMD5(webAdministrator.UserName + webAdministrator.Password);
                webAdministrator.UserId = Guid.NewGuid();
                db.Administrators.Add(webAdministrator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webAdministrator);
        }

        // GET: Admin/WebAdministrators/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebAdministrator webAdministrator = db.Administrators.Find(id);
            if (webAdministrator == null)
            {
                return HttpNotFound();
            }
            return View(webAdministrator);
        }

        // POST: Admin/WebAdministrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password,FullName,Email,Avatar,IsAdmin,IsActive")] WebAdministrator webAdministrator)
        {
            if (ModelState.IsValid)
            {
                webAdministrator.Password = Common.EncryptMD5(webAdministrator.UserName + webAdministrator.Password);
                db.Entry(webAdministrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webAdministrator);
        }

        // GET: Admin/WebAdministrators/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebAdministrator webAdministrator = db.Administrators.Find(id);
            if (webAdministrator == null)
            {
                return HttpNotFound();
            }
            return View(webAdministrator);
        }

        // POST: Admin/WebAdministrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            WebAdministrator webAdministrator = db.Administrators.Find(id);
            db.Administrators.Remove(webAdministrator);
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
