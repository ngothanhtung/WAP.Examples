using System.Diagnostics;
using System.Web.Mvc;

namespace OnlineShopMvcWeb.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {            
            filterContext.Controller.ViewBag.ExceptionMessage = "Custom Exception: Message from OnException method.";
            Debug.WriteLine("Custom Exception: Message from OnException method.");
        }
    }
}