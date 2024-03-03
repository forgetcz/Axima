using Application.Composition;
using Application.Configuration;
using Application.Data;
using Application.Interfaces;
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
        //CrdDataRepository dataRepository = new CrdDataRepository();
        
        [Import(typeof(IDataService))]
        public IDataService dataRepository { get; set; }
        
        public HomeController()
        {
            ComposeApplication.Container.SatisfyImportsOnce(this);
        }

        public async Task<ActionResult> Index()
        {
            
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