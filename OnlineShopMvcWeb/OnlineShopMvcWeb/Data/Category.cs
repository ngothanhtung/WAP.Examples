using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopMvcWeb.Data
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool Status { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}