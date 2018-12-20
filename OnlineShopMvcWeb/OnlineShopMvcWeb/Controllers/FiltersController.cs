using OnlineShopMvcWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMvcWeb.Controllers
{
    // https://www.infragistics.com/community/blogs/b/dhananjay_kumar/posts/how-to-create-a-custom-action-filter-in-asp-net-mvc
    public class FiltersController : Controller
    {
        // GET: Filters
        [CustomActionFilter]
        [CustomAuthorizeFilter]        
        [Authorize]
        [OutputCache(Duration = 5)]
        public ActionResult Index()
        {
            return View();
        }

        [CustomExceptionFilter]
        public ActionResult Error()
        {
            throw new DivideByZeroException();            
            return View();
        }
    }
}