using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OnlineShopMvcWeb.Data
{
    public partial class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string ImageUrl { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal Stock { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int SupplierId { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
