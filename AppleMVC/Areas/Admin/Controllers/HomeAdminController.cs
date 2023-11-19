using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace AppleMVC.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["adminLogin"] == null)
            {
                return RedirectToAction("Index", "Users");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("adminLogin");
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}