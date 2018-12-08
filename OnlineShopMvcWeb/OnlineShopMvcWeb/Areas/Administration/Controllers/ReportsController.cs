using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Dapper;
using OnlineShopMvcWeb.Data;

namespace OnlineShopMvcWeb.Areas.Administration.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Administration/Reports
        public ActionResult Index()
        {
            using (var db = new SqlConnection(GlobalSettings.ConnectionString))
            {
                var sql = "usp_PRODUCTS_GetProductsByCategoryId";
                var products = db.Query<dynamic>(
                    sql: sql, 
                    param: new {CategoryId = 2},
                    commandType: CommandType.StoredProcedure )
                    .ToList();

           
                return View(products);
            }         
        }

        public ActionResult GetJson()
        {
            using (var db = new SqlConnection(GlobalSettings.ConnectionString))
            {
                var sql = "usp_PRODUCTS_GetProductsByCategoryId";
                var products = db.Query<dynamic>(
                        sql: sql,
                        param: new { CategoryId = 2 },
                        commandType: CommandType.StoredProcedure)
                    .ToList();


                return Json(products, JsonRequestBehavior.AllowGet);
            }
        }
    }
}