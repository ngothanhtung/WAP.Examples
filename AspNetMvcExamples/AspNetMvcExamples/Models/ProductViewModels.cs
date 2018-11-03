using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvcExamples.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}