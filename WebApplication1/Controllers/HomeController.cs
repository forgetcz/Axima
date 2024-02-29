using Domain.Interfaces;
using Domain.Entities;
using Infrastrucure.Config;
using Infrastrucure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : AsyncController
    {
        IBaseRepository<ActionDetail, long>  actionDetailRepository;

        public async Task<ActionResult> Index()
        {
            var connection = readwebConfig.sqlConnectionStringConfiguration();
            actionDetailRepository = new ActionDetailRepository(new System.Data.SqlClient.SqlConnection());
            await actionDetailRepository.ReadById(0);
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