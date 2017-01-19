using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_negaheno.Areas.Admin.ViewModels;
using website_negaheno.Areas.Website.ViewModels;
using website_negaheno.DataAccessLayer;

namespace website_negaheno.Areas.Website.Controllers
{
    public class GalleryController : Controller
    {
        IServiceLayer NegahenoService;
        public GalleryController(IServiceLayer _srevice)
        {
            NegahenoService = _srevice;
        }
        // GET: Website/Gallery
        public ActionResult Index(int? page)
        {
            IPagedList<GalleryDetailViewModel> paged_list_gallery = NegahenoService.Get_PreviousGalleryList(page);

            if (Request.IsAjaxRequest())
                return PartialView("_PartialPreviousGalleryList", paged_list_gallery);
            else
                return View(paged_list_gallery);
        }

        public ActionResult GalleryDetail(int id)
        {
            GalleryDetailPageViewModel vm=NegahenoService.Get_GalleryDetail_Page(id);
            return View(vm);
        }
    }
}