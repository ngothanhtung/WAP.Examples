using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopMvcWeb.Data
{
    public class Slider
    {
        public int Id { get; set; }      
        public string Name { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string TargetUrl { get; set; }
        public int SortOrder { get; set; }
        public bool Status { get; set; }       
    }
}