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
    public class WebPostsController : Controller
    {
        private WebDbContext db = new WebDbContext();

        // GET: Admin/WebPosts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(w => w.WebAdministrator).Include(w => w.WebCategory);
            return View(posts.ToList());
        }

        // GET: Admin/WebPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebPost webPost = db.Posts.Find(id);
            if (webPost == null)
            {
                return HttpNotFound();
            }
            return View(webPost);
        }

        // GET: Admin/WebPosts/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Administrators, "UserId", "UserName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Admin/WebPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,Brief,Content,Picture,CreateDate,Tags,CategoryId,ViewNo,Status,UserId")] WebPost webPost)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(webPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Administrators, "UserId", "UserName", webPost.UserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", webPost.CategoryId);
            return View(webPost);
        }

        // GET: Admin/WebPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebPost webPost = db.Posts.Find(id);
            if (webPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Administrators, "UserId", "UserName", webPost.UserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", webPost.CategoryId);
            return View(webPost);
        }

        // POST: Admin/WebPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Title,Brief,Content,Picture,CreateDate,Tags,CategoryId,ViewNo,Status,UserId")] WebPost webPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Administrators, "UserId", "UserName", webPost.UserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", webPost.CategoryId);
            return View(webPost);
        }

        // GET: Admin/WebPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebPost webPost = db.Posts.Find(id);
            if (webPost == null)
            {
                return HttpNotFound();
            }
            return View(webPost);
        }

        // POST: Admin/WebPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebPost webPost = db.Posts.Find(id);
            db.Posts.Remove(webPost);
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
