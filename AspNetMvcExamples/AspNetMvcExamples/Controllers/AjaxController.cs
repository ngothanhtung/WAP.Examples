using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcExamples.Controllers
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
    }
    public class AjaxController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetComments()
        {            
            return Content($"<h2>Hello from AJAX: {DateTime.Now}</h2>");
        }

        public ActionResult GetCommentsWithJson()
        {
            var comments = new List<Comment>();
            comments.Add(new Comment { Id = 1, Text = "Good", UserName = "Peter" });
            comments.Add(new Comment { Id = 2, Text = "Bad", UserName = "John" });


            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PostComment(Comment comment)
        {
            // Save to database
            return Json(comment, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDistricts(string city)
        {
            if (city == "danang")
            {
                var items = new List<dynamic>
                {
                    new { Id = "hc", Name = "Hai Chau" },
                    new { Id = "lc", Name = "Lien Chieu" }
                };
                return Json(items, JsonRequestBehavior.AllowGet);
            }

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}