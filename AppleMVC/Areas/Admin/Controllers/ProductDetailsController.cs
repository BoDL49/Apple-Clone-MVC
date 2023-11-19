using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppleMVC.Models;

namespace AppleMVC.Areas.Admin.Controllers
{
    public class ProductDetailsController : Controller
    {
        private DBAppleStoreEntities db = new DBAppleStoreEntities();

        // GET: Admin/ProductDetails
        public ActionResult Index()
        {
            var productDetails = db.ProductDetails.Include(p => p.Color).Include(p => p.Memory).Include(p => p.Product).Include(p => p.Screen);
            return View(productDetails.ToList());
        }

        // GET: Admin/ProductDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = db.ProductDetails.Find(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            return View(productDetail);
        }

        // GET: Admin/ProductDetails/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.MemoryID = new SelectList(db.Memories, "MemoryID", "MemoryName");
            ViewBag.ProID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.ScreenID = new SelectList(db.Screens, "ScreenID", "ScreenName");
            return View();
        }

        // POST: Admin/ProductDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductDetailID,ProID,ColorID,Price,AppleCareName,ProductImage,ScreenID,MemoryID, UploadImage")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                if (productDetail.UploadImage != null)
                {
                    string path = "~/images/Products/";
                    string filename = Path.GetFileName(productDetail.UploadImage.FileName);
                    productDetail.ProductImage = path + filename;
                    productDetail.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                productDetail.CreateDate = DateTime.Today;
                db.ProductDetails.Add(productDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productDetail.ColorID);
            ViewBag.MemoryID = new SelectList(db.Memories, "MemoryID", "MemoryName", productDetail.MemoryID);
            ViewBag.ProID = new SelectList(db.Products, "ProductID", "ProductName", productDetail.ProID);
            ViewBag.ScreenID = new SelectList(db.Screens, "ScreenID", "ScreenName", productDetail.ScreenID);
            return View(productDetail);
        }

        // GET: Admin/ProductDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = db.ProductDetails.Find(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productDetail.ColorID);
            ViewBag.MemoryID = new SelectList(db.Memories, "MemoryID", "MemoryName", productDetail.MemoryID);
            ViewBag.ProID = new SelectList(db.Products, "ProductID", "ProductName", productDetail.ProID);
            ViewBag.ScreenID = new SelectList(db.Screens, "ScreenID", "ScreenName", productDetail.ScreenID);
            return View(productDetail);
        }

        // POST: Admin/ProductDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductDetailID,ProID,ColorID,Price,AppleCareName,ProductImage,ScreenID,MemoryID, UploadImage")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                if (productDetail.UploadImage != null)
                {
                    string path = "~/images/Products/";
                    string filename = Path.GetFileName(productDetail.UploadImage.FileName);
                    productDetail.ProductImage = path + filename;
                    productDetail.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                db.Entry(productDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productDetail.ColorID);
            ViewBag.MemoryID = new SelectList(db.Memories, "MemoryID", "MemoryName", productDetail.MemoryID);
            ViewBag.ProID = new SelectList(db.Products, "ProductID", "ProductName", productDetail.ProID);
            ViewBag.ScreenID = new SelectList(db.Screens, "ScreenID", "ScreenName", productDetail.ScreenID);
            return View(productDetail);
        }

        // GET: Admin/ProductDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = db.ProductDetails.Find(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            return View(productDetail);
        }

        // POST: Admin/ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDetail productDetail = db.ProductDetails.Find(id);
            db.ProductDetails.Remove(productDetail);
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
