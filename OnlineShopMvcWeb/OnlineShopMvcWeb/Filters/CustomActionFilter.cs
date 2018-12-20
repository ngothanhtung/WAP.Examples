using System.Diagnostics;
using System.Web.Mvc;

namespace OnlineShopMvcWeb.Filters
{
    public class CustomActionFilter: ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage1 = "Custom Action Filter: Message from OnActionExecuting method.";
            Debug.WriteLine("Custom Action Filter: Message from OnActionExecuting method");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage2 = "Custom Action Filter: Message from OnActionExecuted method.";
            Debug.WriteLine("Custom Action Filter: Message from OnActionExecuted method");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage3 = "Custom Action Filter: Message from OnResultExecuting method.";
            Debug.WriteLine("Custom Action Filter: Message from OnResultExecuting method");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.CustomActionMessage4 = "Custom Action Filter: Message from OnResultExecuted method.";
            Debug.WriteLine("Custom Action Filter: Message from OnResultExecuted method");
        }
    }
}