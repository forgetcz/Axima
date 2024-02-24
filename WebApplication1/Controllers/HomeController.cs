using Infrastrucure.Config;
using Infrastrucure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ActionDetailRepository actionDetailRepository;

        public ActionResult Index()
        {
            var connection = readwebConfig.sqlConnectionStringConfiguration();
            actionDetailRepository = new ActionDetailRepository(new System.Data.SqlClient.SqlConnection(connection.SqlConnectionString));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }
    }
}