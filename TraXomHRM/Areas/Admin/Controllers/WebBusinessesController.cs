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
    public class WebBusinessesController : Controller
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/WebBusinesses
        public ActionResult Index()
        {
            return View(db.Businesses.ToList());
        }

        // GET: Admin/WebBusinesses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebBusiness webBusiness = db.Businesses.Find(id);
            if (webBusiness == null)
            {
                return HttpNotFound();
            }
            return View(webBusiness);
        }

        // GET: Admin/WebBusinesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/WebBusinesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusinessId,BusinessName")] WebBusiness webBusiness)
        {
            if (ModelState.IsValid)
            {
                db.Businesses.Add(webBusiness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webBusiness);
        }

        // GET: Admin/WebBusinesses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebBusiness webBusiness = db.Businesses.Find(id);
            if (webBusiness == null)
            {
                return HttpNotFound();
            }
            return View(webBusiness);
        }

        // POST: Admin/WebBusinesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusinessId,BusinessName")] WebBusiness webBusiness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webBusiness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webBusiness);
        }

        // GET: Admin/WebBusinesses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebBusiness webBusiness = db.Businesses.Find(id);
            if (webBusiness == null)
            {
                return HttpNotFound();
            }
            return View(webBusiness);
        }

        // POST: Admin/WebBusinesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WebBusiness webBusiness = db.Businesses.Find(id);
            db.Businesses.Remove(webBusiness);
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
