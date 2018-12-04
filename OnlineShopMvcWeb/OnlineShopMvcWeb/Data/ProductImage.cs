using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopMvcWeb.Data
{
    public class ProductImage
    {
        public int Id { get; set; }      
        public string Caption { get; set; }        
        public string ImageUrl { get; set; }        
        public int SortOrder { get; set; }
        public bool Status { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}