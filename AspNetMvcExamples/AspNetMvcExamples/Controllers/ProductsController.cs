using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetMvcExamples.Data;

namespace AspNetMvcExamples.Controllers
{
    public class ProductsController : Controller
    {
        private OnlineShopDb db = new OnlineShopDb();

        // GET: Products1
        public ActionResult Index(int? categoryId)
        {
            
            if (categoryId.HasValue)
            {
                var products = db.Products.Include(p => p.Category).Where(x => x.CategoryId == categoryId.Value);
                return View(products.ToList());
            }
            else
            {
                var products = db.Products.Include(p => p.Category);
                return View(products.ToList());
            }
           
        }

        // GET: Products1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            var otherProducts = db.Products.Where(x => x.CategoryId == product.CategoryId && x.Id != product.Id).Take(3).ToList();
            ViewBag.OtherProducts = otherProducts;

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
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
