using AppleMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppleMVC.Models;

namespace AppleMVC.Controllers
{
    public class ProductController : Controller
    {
        DBAppleStoreEntities database = new DBAppleStoreEntities();
        // GET: Product
        public ActionResult Index(int? category)
        {
            if(category != null)
             return View(database.ProductDetails.Where(s => s.Product.Category.CategoryID == category).ToList());
            else
                return View(database.ProductDetails.ToList());
        }
    }
}