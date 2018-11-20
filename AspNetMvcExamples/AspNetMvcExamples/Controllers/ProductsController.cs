using AspNetMvcExamples.Data;
using AspNetMvcExamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AspNetMvcExamples.Controllers
{
    public class ProductsController : Controller
    {
        private readonly OnlineShopDb db = new OnlineShopDb();

        public ActionResult Index()
        {
            IList<ProductViewModel> products = db.Products
                .Select(x => new ProductViewModel() { Id = x.Id, Name = x.Name, Price = x.Price })
                .ToList();

            return View();
        }

        public ActionResult Search(string name, decimal? minPrice)
        {
            var products = db.Products.Where(x => x.Id > 0);
            if (string.IsNullOrEmpty(name) == false)
            {
                products = products.Where(x => x.Name.Contains(name));             
            }
          
            if (minPrice.HasValue)
            {
                products = products.Where(x => x.Price >= minPrice);
            }

            IList<ProductViewModel> result = products.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToList();

            return View(result);
        }
    }
}