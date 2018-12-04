using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShopMvcWeb.Data;

namespace OnlineShopMvcWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private OnlineShopDb db = new OnlineShopDb();

        public ActionResult RootCategoriesPartial()
        {
            var categories = this.db.Categories
                .Where(x => x.Status == true && x.ParentId == 0)
                .OrderBy(x => x.SortOrder).ThenBy(x => x.Name)
                .ToList();

            return PartialView("_RootCategoriesPartial", categories);
        }

        public ActionResult CategoriesPartial(int? rootCategoryId)
        {
            var categories = this.db.Categories
                .Where(x => x.Status == true && x.ParentId == rootCategoryId)
                .OrderBy(x => x.SortOrder).ThenBy(x => x.Name)
                .ToList();
            return PartialView("_CategoriesPartial", categories);
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
