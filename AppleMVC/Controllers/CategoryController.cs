using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppleMVC.Models;

namespace AppleMVC.Controllers
{
    public class CategoryController : Controller
    {
        DBAppleStoreEntities database = new DBAppleStoreEntities();
        // GET: Category
        public ActionResult Index()
        {
            var list = database.Categories.ToList();
            ViewBag.listcategory = list;
            return PartialView(list);
        }
    }
}