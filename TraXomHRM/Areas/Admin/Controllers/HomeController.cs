using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraXomHRM.Areas.Admin.Models.BusinessModel;
using TraXomHRM.Areas.Admin.Models.DataModel;

namespace TraXomHRM.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        WebDbContext db = new WebDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string username, string password)
        {
            string passwordMD5 = Common.EncryptMD5(username + password);
            var user = db.Administrators.SingleOrDefault(x => x.UserName == username && x.Password == passwordMD5 && x.IsActive ==true);
            if (user != null)
            {
                Employee nhanvien = user.Employees.FirstOrDefault();
                Session["userid"] = user.UserId;
                Session["username"] = user.UserName;
                Session["fullname"] = user.FullName;
                Session["avatar"] = user.Avatar;
                Session["membersince"] = nhanvien.DateOfBirth.ToString("dd/MM/yyyy");
                return RedirectToAction("Index");
            }
            ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền truy cập";
            return View();
        }
        public ActionResult LogOut()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            Session["avatar"] = null;
            return RedirectToAction("LogIn");

        }
    }
}