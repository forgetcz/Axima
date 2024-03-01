using Application.Configuration;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : AsyncController
    {
        DataRepository dataRepository = new DataRepository();
        AppConfiguration appConfiguration = new AppConfiguration();
        
        public HomeController()
        {

        }

        public async Task<ActionResult> Index()
        {
            //var connection = xmlWebConfig.sqlConnectionStringConfiguration();
            //actionDetailRepository = new ActionDetailRepository(new System.Data.SqlClient.SqlConnection());
            //await actionDetailRepository.ReadById(0);
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