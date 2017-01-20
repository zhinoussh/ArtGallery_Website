using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_negaheno.DataAccessLayer;
using website_negaheno.Models;

namespace website_negaheno.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        IServiceLayer NegaheNoService;

        public ProfileController(IServiceLayer _service)
        {
            NegaheNoService = _service;
        }
        public ActionResult Index()
        {
           return View();
        }

      

  


    }
}