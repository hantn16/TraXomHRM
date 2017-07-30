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
    public class WebCategoriesController : Controller
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/WebCategories
        public ActionResult Index()
        {
            var categories = db.Categories.Include(w => w.WebAdministrator);
            return View(categories.ToList());
        }

        // GET: Admin/WebCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebCategory webCategory = db.Categories.Find(id);
            if (webCategory == null)
            {
                return HttpNotFound();
            }
            return View(webCategory);
        }

        // GET: Admin/WebCategories/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Administrators, "UserId", "UserName");
            return View();
        }

        // POST: Admin/WebCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,OrderNo,Status,UserId")] WebCategory webCategory)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(webCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Administrators, "UserId", "UserName", webCategory.UserId);
            return View(webCategory);
        }

        // GET: Admin/WebCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebCategory webCategory = db.Categories.Find(id);
            if (webCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Administrators, "UserId", "UserName", webCategory.UserId);
            return View(webCategory);
        }

        // POST: Admin/WebCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,OrderNo,Status,UserId")] WebCategory webCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Administrators, "UserId", "UserName", webCategory.UserId);
            return View(webCategory);
        }

        // GET: Admin/WebCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebCategory webCategory = db.Categories.Find(id);
            if (webCategory == null)
            {
                return HttpNotFound();
            }
            return View(webCategory);
        }

        // POST: Admin/WebCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebCategory webCategory = db.Categories.Find(id);
            db.Categories.Remove(webCategory);
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
