using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShopMvcWeb.Data;

namespace OnlineShopMvcWeb.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class ManageProductsController : Controller
    {
        private OnlineShopDb db = new OnlineShopDb();

        // GET: Administration/ManageProducts
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Administration/ManageProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult GetSubCategories(int parentId)
        {
            var categories = db.Categories.Where(x => x.ParentId == parentId).OrderBy(x => x.SortOrder).ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        // GET: Administration/ManageProducts/Create
        public ActionResult Create()
        {
            var parentCategories = db.Categories.Where(x => x.ParentId == 0).OrderBy(x => x.SortOrder).ToList();

            ViewBag.ParentCategoryId = new SelectList(parentCategories, "Id", "Name");

            var categories = new List<Category>
            {
                new Category() { Id = 0, Name = "[Select a category]", ParentId = 0, SortOrder = -1, Status = true }
            };


            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }



        // POST: Administration/ManageProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImageUrl,Price,Discount,Stock,Description,CategoryId,SupplierId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var parentCategories = db.Categories.Where(x => x.ParentId == 0).OrderBy(x => x.SortOrder).ToList();

            ViewBag.ParentCategoryId = new SelectList(parentCategories, "Id", "Name");

            var categories = new List<Category>
            {
                new Category() { Id = 0, Name = "[Select a category]", ParentId = 0, SortOrder = -1, Status = true }
            };


            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View(product);
        }

        // GET: Administration/ManageProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Administration/ManageProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImageUrl,Price,Discount,Stock,Description,CategoryId,SupplierId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Administration/ManageProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Administration/ManageProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Upload(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file, int id)
        {
            var defaultFolderToSaveFile = "~/Uploads/Products/" + id + "/";
            if (Directory.Exists(Server.MapPath(defaultFolderToSaveFile)) == false)
            {
                Directory.CreateDirectory(Server.MapPath(defaultFolderToSaveFile));
            }

            if (ModelState.IsValid)
            {
                // Verify that the user selected a file
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    if (fileName != null)
                    {
                        var path = Path.Combine(Server.MapPath(defaultFolderToSaveFile), fileName);

                        // Upload file lên Server ở thư mục ~/Uploads/
                        file.SaveAs(path);

                        // Lay image url de luu vao database, co dinh dang "~/Uploads/ten_file.jpg"
                        var imageUrl = defaultFolderToSaveFile + fileName;
                        // Lưu vào database
                        var product = db.Products.Find(id);

                        if (product == null) return HttpNotFound();

                        product.ImageUrl = imageUrl;
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
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
