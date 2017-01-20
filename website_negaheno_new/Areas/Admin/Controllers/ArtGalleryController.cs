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
           NegahenoService.Post_Insert_New_Gallery(vm);
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
            NegahenoService.Post_Delete_Gallery(vm);
            return Json(new { page_index = vm.filter_page.page, filter = vm.filter_page.filter+"" });
        }

        [HttpGet]
        public ActionResult Get_PosterModal(int id)
        {
            GalleryImagesViewModel vm=NegahenoService.Get_PartialPoster(id,this);
            return PartialView("_PartialAddPoster", vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPoster(HttpPostedFileBase image, int GalleryId, string GalleryName, string filter, int page)
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

        [HttpGet]
        public ActionResult Images(int id, int? page)
        {
            GalleryImagesViewModel vm = NegahenoService.Get_ArtGallery_Images(id,page, this);

            if (Request.IsAjaxRequest())
                return PartialView("_PartialImagesList", vm.gallery_images);
            else
                return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage(HttpPostedFileBase image, int GalleryId, int page)
        {
            GalleryImagesViewModel vm = new GalleryImagesViewModel()
            {
                GalleryID = GalleryId,
                image = image
            };
            NegahenoService.Post_AddGalleryImage(vm, this);

            return Json(new { msg = "image uploaded successfully!", page_index = page,galleryID=GalleryId});
        }

        [HttpGet]
        public ActionResult DeleteImage(string img_path)
        {
            ImageViewModel vm = NegahenoService.Get_Delete_GalleryImage(img_path, this);
            return PartialView("_PartialDeleteImage", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteImage(ImageViewModel vm)
        {
            NegahenoService.Post_Delete_GalleryImage(vm.ImageId,this);
            return Json(new { msg = "image deleted successfully!", page_index = vm.page, galleryID = vm.GalleryId });
        }

        [HttpGet]
        public ActionResult Get_ZoomImage(string img_path)
        {
            img_path = img_path + "?"  + DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            return PartialView("_PartialImage", img_path);
        }
    }
}