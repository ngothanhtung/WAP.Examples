using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopMvcWeb.Data;

namespace OnlineShopMvcWeb.Controllers
{
    public class CartItem
    {
        public int ProductId { get; set; }
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Quantity { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total => this.ProductPrice * this.Quantity * (100 - this.Discount) / 100;
    }

    public class ShoppingCartsController : Controller
    {
        private OnlineShopDb db = new OnlineShopDb();

        [HttpPost]
        public ActionResult AddToCart(int productId, decimal quantity)
        {
            var product = db.Products.Find(productId);

            if (Session["ShoppingCart"] == null)
            {
                var shoppingCarts = new List<CartItem>();
                var itemCart = new CartItem {ProductId = productId, ProductName = product.Name, ProductPrice = product.Price, Quantity = quantity, Discount = product.Discount};

                shoppingCarts.Add(itemCart);

                Session["ShoppingCart"] = shoppingCarts;
                
                return Json(shoppingCarts, JsonRequestBehavior.AllowGet);
            }

            var existsShoppingCarts = (List<CartItem>)Session["ShoppingCart"];
            var existsItem = existsShoppingCarts.FirstOrDefault(x => x.ProductId == productId);

            if (existsItem != null)
            {
                existsItem.Quantity++;
                Session["ShoppingCart"] = existsShoppingCarts;

                return Json(existsShoppingCarts, JsonRequestBehavior.AllowGet);
            }

            existsShoppingCarts.Add(new CartItem
            {
                ProductId = productId,
                ProductName = product.Name,
                ProductPrice = product.Price,
                Quantity = quantity
            });

            Session["ShoppingCart"] = existsShoppingCarts;

            return Json(existsShoppingCarts, JsonRequestBehavior.AllowGet);
        }
    }
}