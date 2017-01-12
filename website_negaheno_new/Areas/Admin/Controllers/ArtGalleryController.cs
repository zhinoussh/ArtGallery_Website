using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_negaheno.Areas.Admin.ViewModels;
using PagedList;
using website_negaheno.DataAccessLayer;

namespace website_negaheno.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class ArtGalleryController : Controller
    {
        IServiceLayer NegahenoService;
        public ArtGalleryController(IServiceLayer _service)
        {
            NegahenoService = _service;
        }

        // GET: Admin/ArtGallery
        public ActionResult Index(SearchPaginationViewModel vm)
        {
            GalleryPageViewModel page_vm = NegahenoService.Get_Index_ArtGalery(vm);
           
            if (Request.IsAjaxRequest())
                return PartialView("_PartialGalleryList", page_vm.paged_list_artGallery);
            else
            {
                return View(page_vm);
            }
        }

        [HttpGet]
        public ActionResult Insert_New_Gallery()
        {
            ArtGalleryViewModel vm = new ArtGalleryViewModel();
            return PartialView("_PartialAddGallery");
        }

        [HttpPost]
        public ActionResult Insert_Gallery(ArtGalleryViewModel vm)
        {
            return  Json(new { msg = "" });
        }
    }
}