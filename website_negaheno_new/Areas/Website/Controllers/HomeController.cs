using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_negaheno.DataAccessLayer;
using website_negaheno.ViewModels;

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
            HomePageViewModel vm = new HomePageViewModel();
            vm.lst_current_gallery= NegaheNoService.Get_Current_Gallery();
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