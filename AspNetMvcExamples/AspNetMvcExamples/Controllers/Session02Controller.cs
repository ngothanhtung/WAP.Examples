using AspNetMvcExamples.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcExamples.Controllers
{
    public class Session02Controller : Controller
    {
        // GET: Product

        public ActionResult Index()
        {

            var products = GetProducts();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var products = GetProducts();
            var product = products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        public ActionResult EmptyResultExample()
        {
            return new EmptyResult();
        }

        public ActionResult NewProductsPartial()
        {
            var products500 = this.GetProducts().Where(x =>x.Price >= 500).ToList();

            return PartialView("_NewProductsPartial", products500); // pass DataModel to PartialPage
        }

        public ActionResult ProductDetailsPartial(int id)
        {
            var products = this.GetProducts();
            var product = products.FirstOrDefault(x => x.Id == id);
            return PartialView("_ProductDetailsPartial", product); // pass DataModel to PartialPage
        }

        public ActionResult RedirectResultExample()
        {
            //return Redirect("http://www.google.com");
            return RedirectToAction("Index", "Home");
        }

        // RedirectResult
        public ActionResult JsonResultExample()
        {
            var students = new List<Student>();
            students.Add(new Student() {Id = 1, Name = "Peter"});
            students.Add(new Student() {Id = 2, Name = "John"});
            students.Add(new Student() {Id = 3, Name = "Obama"});
            students.Add(new Student() {Id = 4, Name = "Putin"});
            return Json(students, JsonRequestBehavior.AllowGet);

        }

        public ActionResult HtmlResultExample()
        {
            return Content("<h1>This is HTML from AJAX</h1>");
        }

        private IList<Product> GetProducts()
        {
            var products = new List<Product>();

            // Product 1
            var p1 = new Product();
            p1.Id = 1;
            p1.Name = "iPhone 6";
            p1.Price = 500;
            p1.ImageUrl = "~/Uploads/Images/iphone6.jpg";
            products.Add(p1);

            // Product 2
            var p2 = new Product();
            p2.Id = 2;
            p2.Name = "iPhone 6s";
            p2.Price = 600;
            p2.ImageUrl = "~/Uploads/Images/iphone6s.jpg";
            products.Add(p2);

            // Product 3
            var p3 = new Product();
            p3.Id = 3;
            p3.Name = "iPhone 6s Plus";
            p3.Price = 800;
            p3.ImageUrl = "~/Uploads/Images/iphone6splus.jpg";
            products.Add(p3);

            // Product 4
            var p4 = new Product();
            p4.Id = 4;
            p4.Name = "iPhone SE";
            p4.Price = 400;
            p4.ImageUrl = "~/Uploads/Images/iphoneSE.jpg";
            products.Add(p4);

            return products;
        }

        public class Student
        {
            public int Id { set; get; }
            public string Name { set; get; }
        }

    }
}