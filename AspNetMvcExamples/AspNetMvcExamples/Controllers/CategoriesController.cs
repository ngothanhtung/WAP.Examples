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
    public class CategoriesController : Controller
    {
        private OnlineShopDb db = new OnlineShopDb();

      

        public ActionResult CategoriesPartial()
        {
            var categories = this.db.Categories.OrderBy(x => x.Name).ToList();
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
