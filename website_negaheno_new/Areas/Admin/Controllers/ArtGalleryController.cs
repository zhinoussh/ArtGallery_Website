using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website_negaheno.Areas.Admin.ViewModels;
using PagedList;

namespace website_negaheno.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class ArtGalleryController : Controller
    {
        // GET: Admin/ArtGallery
        public ActionResult Index(SearchPaginationViewModel vm)
        {
            List<ArtGalleryViewModel> lst_gallery = new List<ArtGalleryViewModel>();

            lst_gallery.Add(new ArtGalleryViewModel()
            {
                GaleeryId = 1,
                fa_title = "gallery1",
                description = "desc gallery 1",
                fromDate = "1395/01/01"
                ,
                toDate = "1395/01/01",
                fromHour = "16:00",
                toHour = "20:00"
            });

            lst_gallery.Add(new ArtGalleryViewModel()
            {
                GaleeryId = 2,
                fa_title = "gallery2",
                description = "desc gallery 1",
                fromDate = "1395/07/01"
                ,
                toDate = "1395/07/14",
                fromHour = "16:00",
                toHour = "20:00"
            });

            lst_gallery=lst_gallery.Select((x, Index) => new ArtGalleryViewModel()
            {
                rowNumber = Index + 1,
                GaleeryId = x.GaleeryId
                ,
                fa_title = x.fa_title,
                description = x.description,
                fromDate = x.fromDate
                ,
                toDate = x.toDate,
                fromHour = x.fromHour,
                toHour = x.toHour
            }).ToList();

            int currentpage = vm.page.HasValue ? vm.page.Value : 1;
            IPagedList<ArtGalleryViewModel> paged_list_artGallery = lst_gallery.ToPagedList(currentpage, 1);

            if (Request.IsAjaxRequest())
                return PartialView("_PartialGalleryList", paged_list_artGallery);
            else
            {
                GalleryPageViewModel page_vm = new GalleryPageViewModel()
                {
                    paged_list_artGallery = paged_list_artGallery,
                    search_pagination_params = new SearchPaginationViewModel() { 
                        page=1
                        ,filter=""
                    }
                };
                return View(page_vm);
            }
        }
    }
}