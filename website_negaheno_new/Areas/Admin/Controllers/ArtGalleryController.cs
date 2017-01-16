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
        public ActionResult Index(int?page,string filter)
        {
            SearchPaginationViewModel search_vm = new SearchPaginationViewModel()
            {
                filter = filter + "",
                page = page.HasValue ? page.Value : 1
            };

            GalleryPageViewModel page_vm = NegahenoService.Get_Index_ArtGallery(search_vm,this);

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
           IPagedList<ArtGalleryViewModel> newTableContent= NegahenoService.Post_Insert_New_Gallery(vm,this);
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
            IPagedList<ArtGalleryViewModel> newTableContent = NegahenoService.Post_Delete_Gallery(vm,this);
            return Json(new { page_index = vm.filter_page.page, filter = vm.filter_page.filter+"" });
        }

        [HttpGet]
        public ActionResult Get_PosterModal(int id)
        {
            GalleryImagesViewModel vm=NegahenoService.Get_PartialPoster(id,this);
            return PartialView("_PartialAddPoster", vm);
        }
        
        [HttpPost]
        public ActionResult AddPoster(HttpPostedFileBase image, int GalleryId, string GalleryName,string filter,int page)
        {
            GalleryImagesViewModel vm = new GalleryImagesViewModel()
            {
                GalleryID = GalleryId,
                GalleryName = GalleryName,
                image = image
            };
            NegahenoService.Post_AddGalleryPoster(vm,this);

            return Json(new { msg = "poster uploaded successfully!" ,page_index = page, filter = filter+""});
        }

        [HttpGet]
        public ActionResult Get_GalleryDetail(int id) {

            GalleryDetailViewModel vm = NegahenoService.Get_PartialDetail(id,this);
            return PartialView("_PartialDetailGallery",vm);
        }
    }
}