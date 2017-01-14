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
            GalleryPageViewModel page_vm = NegahenoService.Get_Index_ArtGallery(vm);

            TempData["page"] = vm.page;
            TempData["filter"] = vm.filter;

            if (Request.IsAjaxRequest())
                return PartialView("_PartialGalleryList", page_vm.paged_list_artGallery);
            else
            {
                return View(page_vm);
            }
        }

        [HttpGet]
        public ActionResult Insert_New_Gallery(int? id)
        {
            ArtGalleryViewModel vm = NegahenoService.Get_Insert_New_Gallery(id,this);
            return PartialView("_PartialAddGallery", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelValidator]
        public ActionResult Insert_New_Gallery(ArtGalleryViewModel vm)
        {
           IPagedList<ArtGalleryViewModel> newTableContent= NegahenoService.Post_Insert_New_Gallery(vm);
           return Json(new { page_index = vm.filter_page.page, filter = vm.filter_page.filter + "" });
        }


        [HttpGet]
        public ActionResult Delete_Gallery(int? id)
        {
            ArtGalleryViewModel vm = NegahenoService.Get_Delete_Gallery(id,this);
            return PartialView("_PartialDeleteGallery", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_Gallery(ArtGalleryViewModel vm)
        {
            IPagedList<ArtGalleryViewModel> newTableContent = NegahenoService.Post_Delete_Gallery(vm);
            return Json(new { page_index = vm.filter_page.page, filter = vm.filter_page.filter+"" });
        }

    }
}