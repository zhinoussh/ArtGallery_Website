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

        public GalleryPageViewModel Get_Index_ArtGallery(SearchPaginationViewModel search_pagination_vm,Controller ctrl)
        {
            ctrl.TempData["page"] = search_pagination_vm.page;
            ctrl.TempData["filter"] = search_pagination_vm.filter;

            GalleryPageViewModel page_vm = new GalleryPageViewModel();

            List<ArtGalleryViewModel> lst_gallery = DataLayer.Get_ArtGalleryList();

            lst_gallery = FilterGalleryList(lst_gallery, search_pagination_vm.filter);

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



        public IPagedList<ArtGalleryViewModel> Post_Insert_New_Gallery(ArtGalleryViewModel vm, Controller ctrl)
        {
            DataLayer.Insert_New_ArtGallery(vm);

            GalleryPageViewModel gallery_page = Get_Index_ArtGallery(vm.filter_page,ctrl);
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

        public IPagedList<ArtGalleryViewModel> Post_Delete_Gallery(ArtGalleryViewModel vm, Controller ctrl)
        {
            
            DataLayer.Delet_ArtGallery(vm.GalleryId);

            GalleryPageViewModel page = Get_Index_ArtGallery(vm.filter_page,ctrl);
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

            vm.filter_page = Get_SearchPagination_Params(ctrl);

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

        public GalleryDetailViewModel Get_PartialDetail(int id, Controller ctrl)
        {
            GalleryDetailViewModel vm = new GalleryDetailViewModel();

            ArtGalleryViewModel gallery = DataLayer.get_ArtGallery_byID(id);

            vm.fa_title = gallery.fa_title;
            vm.eng_title = gallery.eng_title;
            vm.openning_hours = gallery.fromHour + " - " + gallery.toHour;
            vm.visit_dates = gallery.fromDate + " - " + gallery.toDate;

            string poster_path = "/Upload/gallery_" + gallery.GalleryId + "/poster.jpg";
            if (File.Exists(ctrl.Server.MapPath(@poster_path)))
                vm.poster_path = poster_path + "?" + DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            else
                vm.poster_path = "/images/empty.gif?" + DateTime.Now.ToString("ddMMyyyyhhmmsstt");


            return vm;
        }

        private SearchPaginationViewModel Get_SearchPagination_Params(Controller ctrl)
        {
            SearchPaginationViewModel params_search_pagination = new SearchPaginationViewModel()
            {
                page = ctrl.TempData["page"] == null ? 1 : Int32.Parse(ctrl.TempData["page"].ToString()),
                filter = ctrl.TempData["filter"] == null ? "" : ctrl.TempData["filter"].ToString()
            };

            return params_search_pagination;
        }

        private List<ArtGalleryViewModel> FilterGalleryList(List<ArtGalleryViewModel> lst_gallery,string filter)
        {
            if (!String.IsNullOrEmpty(filter))
                lst_gallery=lst_gallery.Where(x => (!String.IsNullOrEmpty(x.fa_title) && x.fa_title.Contains(filter))
                                     || (!String.IsNullOrEmpty(x.eng_title) && x.eng_title.Contains(filter))
                                     || (!String.IsNullOrEmpty(x.fromDate) && x.fromDate.Contains(filter))
                                     || (!String.IsNullOrEmpty(x.toDate) && x.toDate.Contains(filter))
                                     ).ToList();

            return lst_gallery;
                                     
        }

    }
}