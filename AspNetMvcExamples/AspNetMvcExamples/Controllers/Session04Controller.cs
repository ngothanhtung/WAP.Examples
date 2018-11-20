using AspNetMvcExamples.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNetMvcExamples.Controllers
{
    public class Session04Controller : Controller
    {
        // GET: Session04
        public ActionResult Index()
        {
            var products = this.GetProducts();
            return View(products);
        }


        private IList<DummyProduct> GetProducts()
        {
            var products = new List<DummyProduct>();

            // Product 1
            var p1 = new DummyProduct();
            p1.Id = 1;
            p1.Name = "iPhone 6";
            p1.Price = 500;
            p1.ImageUrl = "~/Uploads/Images/iphone6.jpg";
            p1.Category = "Mobile Phone";
            products.Add(p1);

            // Product 2
            var p2 = new DummyProduct();
            p2.Id = 2;
            p2.Name = "iPhone 6s";
            p2.Price = 600;
            p2.ImageUrl = "~/Uploads/Images/iphone6s.jpg";
            p2.Category = "Mobile Phone";
            products.Add(p2);

            // Product 3
            var p3 = new DummyProduct();
            p3.Id = 3;
            p3.Name = "iPhone 6s Plus";
            p3.Price = 800;
            p3.ImageUrl = "~/Uploads/Images/iphone6splus.jpg";
            p3.Category = "Mobile Phone";
            products.Add(p3);

            // Product 4
            var p4 = new DummyProduct();
            p4.Id = 4;
            p4.Name = "iPhone SE";
            p4.Price = 400;
            p4.ImageUrl = "~/Uploads/Images/iphoneSE.jpg";
            p4.Category = "Other Phone";
            products.Add(p4);

            return products;
        }
    }
}