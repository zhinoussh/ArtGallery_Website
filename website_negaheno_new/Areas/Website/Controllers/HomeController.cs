using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_negaheno.Areas.Website.ViewModels;
using website_negaheno.DataAccessLayer;

namespace website_negaheno.Areas.Website.Controllers
{
    public class HomeController : Controller
    {
        IServiceLayer NegaheNoService;

        public HomeController(IServiceLayer _service)
        {
            NegaheNoService = _service;
        }

        public ActionResult Index()
        {
            HomePageViewModel vm = NegaheNoService.Get_HomePage();
            return View(vm);
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