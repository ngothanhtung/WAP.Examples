using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopMvcWeb.Data
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}