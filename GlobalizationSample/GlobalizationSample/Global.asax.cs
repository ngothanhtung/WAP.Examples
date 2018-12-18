using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GlobalizationSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            // Trường hợp thiết lập bằng CODE ở đây sẽ chạy đè thiết lập ở WEB.CONFIG
            //<globalization enableClientBasedCulture="true" culture="auto:vi-VN" uiCulture="auto:vi"/>

            // TRƯỜNG HỢP 1:
            // TRƯỜNG hợp xác định LANGUAGE bằng cách đọc thông tin từ REQUEST (gửi từ trình duyệt WEB - BROWSER)
            // Nếu BROWSER được thiết lập theo LANGUAGE nào thì THREAD chuyển sang CULTURE tương ứng

            /*
            if (Request.UserLanguages != null)
            {
                var language = Request.UserLanguages[0];
               
                switch (language)
                {
                    case "vi":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
                        break;
                    case "fr":
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
                        break;
                }
            }
            */

            // TRƯỜNG HỢP 2:
            // TRƯỜNG hợp xác định LANGUAGE bằng cách đọc thông tin từ WEB.CONFIG
            //<appSettings>
            //    <add key="Language" value="vi-VN"/>
            //</appSettings>
            var language = System.Configuration.ConfigurationManager.AppSettings["Language"];
            switch (language)
            {
                case "vi":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
                    break;
                case "fr":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
                    break;
            }
        }
    }
}
