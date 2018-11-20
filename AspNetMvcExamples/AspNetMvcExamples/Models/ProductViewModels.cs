using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMvcExamples.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }      
        public decimal Price { get; set; }
    }

    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        [Column(TypeName = "money")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid number")]
        [Required(ErrorMessage = "*")]
        public decimal Price { get; set; }      
        public int CategoryId { get; set; }
    }

   public class DummyProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}