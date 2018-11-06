using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcExamples.Controllers
{
    public class LoginDataModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class Session03Controller : Controller
    {
        // GET: Session03
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Razor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HtmlHelper(LoginDataModel data)
        {
            return View();
        }
        public ActionResult HtmlHelper()
        {
            var cities = new[]
            {
                new { ID = "DANANG", Name = "Chi nhánh Đà Nẵng - 38 Đường Yên Bái" },
                new { ID = "HUE", Name = "Chi nhánh Huế - 5A Đường Phong Châu (Big C)" },
                new { ID = "CANTHO", Name = "Chi nhánh Cần Thơ - 118 Đường 3/2" }
            };
            ViewBag.CityList = new SelectList(cities, "ID", "Name", "HUE");
            ViewBag.City = new SelectList(cities, "ID", "Name", "DANANG");
            return View();
        }
    }
}