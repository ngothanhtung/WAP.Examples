using System.Diagnostics;
using System.Web.Mvc;

namespace OnlineShopMvcWeb.Filters
{
    public class CustomAuthorizeFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.AutherizationMessage = "Custom Authorization: Message from OnAuthorization method.";
            Debug.WriteLine("Custom Authorization: Message from OnAuthorization method.");
        }
    }
}