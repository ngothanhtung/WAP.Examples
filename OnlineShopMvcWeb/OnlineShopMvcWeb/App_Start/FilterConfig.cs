using OnlineShopMvcWeb.Filters;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMvcWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // GLOBALE LEVEL            
            filters.Add(new HandleErrorAttribute());

            // GLOBALE LEVEL            
            filters.Add(new CustomActionFilter());
            filters.Add(new CustomAuthorizeFilter());
            filters.Add(new CustomExceptionFilter());
        }
    }
}
