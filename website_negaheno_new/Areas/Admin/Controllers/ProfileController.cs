﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_negaheno.Models;

namespace website_negaheno.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        // GET: Admin/Profile
        public ActionResult Index()
        {
            return View();
        }

  


    }
}