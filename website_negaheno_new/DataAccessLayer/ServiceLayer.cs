using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_negaheno.Areas.Admin.ViewModels;
using PagedList;
using System.Web.Mvc;
using System.IO;

namespace website_negaheno.DataAccessLayer
{
    public class ServiceLayer:IServiceLayer
    {
        private IDataRepository _dataLayer;

        private const int pagesize=5;

        public IDataRepository DataLayer
        {
            get
            {
                if (_dataLayer == null)
                    _dataLayer = new DataRepository(new NegaheNoDB());

                return _dataLayer;
            }
            set
            {
                _dataLayer = value;
            }
        }

        public GalleryPageViewModel Get_Index_ArtGallery(SearchPaginationViewModel search_pagination_vm)
        {
            GalleryPageViewModel page_vm = new GalleryPageViewModel();

            List<ArtGalleryViewModel> lst_gallery = DataLayer.Get_ArtGalleryList();

            lst_gallery = lst_gallery.Select((x, Index) => new ArtGalleryViewModel()
            {
                rowNumber = Index + 1,
                GalleryId = x.GalleryId,
                fa_title = x.fa_title,
                description = x.description,
                fromDate = x.fromDate,
                toDate = x.toDate,
                fromHour = x.fromHour,
                toHour = x.toHour
            }).ToList();

            if (search_pagination_vm == null)
            {
                search_pagination_vm = new SearchPaginationViewModel()
                {
                    page = 1,
                    filter = ""
                };
            }

            int currentpage = search_pagination_vm.page.HasValue ? search_pagination_vm.page.Value : 1;
            IPagedList<ArtGalleryViewModel> paged_list_artGallery = lst_gallery.ToPagedList(currentpage, pagesize);

            page_vm.paged_list_artGallery = paged_list_artGallery;
            page_vm.search_pagination_params = search_pagination_vm;

            return page_vm;
        }


        public ArtGalleryViewModel Get_Insert_New_Gallery(int? id, Controller ctrl)
        {
            int gallery_id = id.HasValue ? id.Value : 0;

            ArtGalleryViewModel vm;
            if (gallery_id == 0)
            {
                vm = new ArtGalleryViewModel();
                vm.fromHour = "16:00";
                vm.toHour = "20:00";
            }
            else
            {
                vm = DataLayer.get_ArtGallery_byID(gallery_id);
            }

            vm.filter_page = Get_SearchPagination_Params(ctrl);
            
            return vm;                 
        }

        private SearchPaginationViewModel Get_SearchPagination_Params(Controller ctrl)
        {
            SearchPaginationViewModel params_search_pagination= new SearchPaginationViewModel(){
                page = ctrl.TempData["page"]==null ? 1 :Int32.Parse(ctrl.TempData["page"].ToString()),
                filter = ctrl.TempData["filter"]==null?"": ctrl.TempData["filter"].ToString() 
            };

            return params_search_pagination;
        }

      
        public IPagedList<ArtGalleryViewModel> Post_Insert_New_Gallery(ArtGalleryViewModel vm)
        {
            DataLayer.Insert_New_ArtGallery(vm);

            GalleryPageViewModel gallery_page = Get_Index_ArtGallery(vm.filter_page);
            if (gallery_page != null)
            {
                return (IPagedList<ArtGalleryViewModel>)gallery_page.paged_list_artGallery;
            }
            else
                return null;
        }

        public ArtGalleryViewModel Get_Delete_Gallery(int? id, Controller ctrl)
        {
            ArtGalleryViewModel vm = new ArtGalleryViewModel();
            vm.GalleryId = id.HasValue ? id.Value : 0;
            vm.filter_page = Get_SearchPagination_Params(ctrl);
            return vm;        
        }

        public IPagedList<ArtGalleryViewModel> Post_Delete_Gallery(ArtGalleryViewModel vm) {
            
            DataLayer.Delet_ArtGallery(vm.GalleryId);

            GalleryPageViewModel page = Get_Index_ArtGallery(vm.filter_page);
            if (page != null)
                return (IPagedList<ArtGalleryViewModel>)page.paged_list_artGallery;
            else
                return null;


        }

        public GalleryImagesViewModel Get_PartialPoster(int id, Controller ctrl)
        {
            GalleryImagesViewModel vm = new GalleryImagesViewModel();

            ArtGalleryViewModel gallery=DataLayer.get_ArtGallery_byID(id);

            vm.GalleryID = id;
            vm.GalleryName = gallery.fa_title.Length>50 ? (gallery.fa_title.Substring(0,50)+"...") : gallery.fa_title;
            
            string poster_path="/Upload/gallery_" + vm.GalleryID+ "/poster.jpg";
            if(File.Exists(ctrl.Server.MapPath(@poster_path)))
                vm.image_path = poster_path +"?"+  DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            else
                vm.image_path = "/images/empty.gif?" + DateTime.Now.ToString("ddMMyyyyhhmmsstt");


            return vm;
        }
        public void Post_AddGalleryPoster(GalleryImagesViewModel vm, Controller ctrl) {
            
            if (vm.image != null)
            {
                    string save_dir = ctrl.Server.MapPath(@"~\Upload\gallery_" + vm.GalleryID);
                    if (!Directory.Exists(save_dir))
                        Directory.CreateDirectory(save_dir);

                    vm.image.SaveAs(save_dir + "\\poster.jpg");
            }
        }
    }
}