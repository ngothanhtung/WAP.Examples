using OnlineShopMvcWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMvcWeb.Controllers
{
    public class SlidersController : Controller
    {
        private OnlineShopDb db = new OnlineShopDb();

        public ActionResult SlidersPartial()
        {
            var sliders = this.db.Sliders
                .Where(x => x.Status == true)
                .OrderBy(x => x.SortOrder)
                .ToList();

            return PartialView("_SlidersPartial", sliders);
        }

    }
}