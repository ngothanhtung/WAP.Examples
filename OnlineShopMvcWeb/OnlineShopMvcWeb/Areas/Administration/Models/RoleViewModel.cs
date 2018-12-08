using System.ComponentModel.DataAnnotations;

namespace OnlineShopMvcWeb.Areas.Administration.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }
}