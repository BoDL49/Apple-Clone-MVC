using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AppleMVC.Models;

namespace AppleMVC.Controllers
{
    public class UsersController : Controller
    {
        private DBAppleStoreEntities db = new DBAppleStoreEntities();

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserName,UserPhone,NameUser,UserEmail,UserPassword,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                User check = db.Users.FirstOrDefault(s => s.UserName == user.UserName);
                if (check == null)
                {
                    user.RoleID = 0;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return View();
                }
                else
                {
                    ViewBag.error = "Tài khoản đã tồn tại";
                    return View();
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string UserName, string UserPassword)
        {
            if (ModelState.IsValid)
            {
                //var check = db.Users.Where(s => s.UserName == UserName && s.UserPassword == UserPassword).FirstOrDefault();
                var check = db.Users.SingleOrDefault(s => s.UserName.ToLower() == UserName.ToLower() && s.UserPassword == UserPassword);
                if (check == null)
                {
                    ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu";
                    return View();
                }
                else
                {
                    if (check.UserPassword != UserPassword)
                    {
                        ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu";
                        return View();
                    }
                    else
                    {
                        if (check.RoleID == 0)
                        {
                            Session["userLogin"] = check;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            Session["userLogin"] = check;
                            Session["adminLogin"] = check;
                            return RedirectToAction("HomeAdmin", "Admin");
                        }
                        
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("userLogin");
            Session.Remove("adminLogin");
            Session.Remove("hoTen");
            Session.Remove("email");
            Session.Remove("sdt");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
