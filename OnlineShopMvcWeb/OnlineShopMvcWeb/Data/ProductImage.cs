using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopMvcWeb.Data
{
    public class ProductImage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Caption { get; set; }

        [Required]
        [StringLength(1000)]
        public string ImageUrl { get; set; }

        public int SortOrder { get; set; }

        public bool Status { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}