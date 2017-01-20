using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_negaheno.Areas.Admin.ViewModels;
using website_negaheno.DataAccessLayer;

namespace website_negaheno.Areas.Admin.Controllers
{
    public class PhotoGalleryController : Controller
    {
        IServiceLayer NegahenoService;
        public PhotoGalleryController(IServiceLayer _service)
        {
            NegahenoService = _service;    
        }
        // GET: Admin/PhotoGaller
        public ActionResult Index(int? page)
        {
            PhotoAlbumViewModel vm = NegahenoService.Get_PhotoAlbum_Images(page, this);

            if (Request.IsAjaxRequest())
                return PartialView("_PartialAlbumList", vm.photos);
            else
                return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage(HttpPostedFileBase image, int page)
        {
            NegahenoService.Post_AddPhotoAlbumImage(image, this);
            return Json(new { msg = "image uploaded successfully!", page_index = page });
        }

        [HttpGet]
        public ActionResult DeleteImage(string img_path)
        {
            ImageViewModel vm = NegahenoService.Get_Delete_PhotoAlbumImage(img_path, this);
            return PartialView("_PartialDeletePhotoAlbum", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteImage(ImageViewModel vm)
        {
            NegahenoService.Post_Delete_PhotoAlbumImage(vm.ImageId, this);
            return Json(new { msg = "image deleted successfully!", page_index = vm.page});
        }

    }
}