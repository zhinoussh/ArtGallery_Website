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
            SearchPaginationViewModel filter_page = new SearchPaginationViewModel();
            filter_page.page = Request["page"] == null ? 1 : Int32.Parse(Request["page"].ToString());
            filter_page.filter = Request["filter"] == null ? "" : Request["page"].ToString();

            int gallery_id= id.HasValue ? id.Value : 0;
            ArtGalleryViewModel vm = NegahenoService.Get_Insert_New_Gallery(gallery_id, filter_page);
            return PartialView("_PartialAddGallery", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelValidator]
        public ActionResult Insert_New_Gallery(ArtGalleryViewModel vm)
        {
           IPagedList<ArtGalleryViewModel> newTableContent= NegahenoService.Post_Insert_New_Gallery(vm);
           return PartialView("_PartialGalleryList", newTableContent);

        }
    }
}