using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_negaheno.Areas.Admin.ViewModels;
using PagedList;
using System.Web.Mvc;

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


        public ArtGalleryViewModel Get_Insert_New_Gallery(int ?id,Controller ctrl)
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

            vm.filter_page = Get_SearchPagination_Params(ctrl, vm);
            
            return vm;                 
        }

      
        public IPagedList<ArtGalleryViewModel> Post_Insert_New_Gallery(ArtGalleryViewModel vm)
        {
            DataLayer.Insert_New_ArtGallery(vm);

            GalleryPageViewModel page = Get_Index_ArtGallery(vm.filter_page);
            if (page != null)
                return (IPagedList<ArtGalleryViewModel>)page.paged_list_artGallery;
            else
                return null;
        }

        public ArtGalleryViewModel Get_Delete_Gallery(int? id, Controller ctrl)
        {
            ArtGalleryViewModel vm = new ArtGalleryViewModel();
            vm.GalleryId = id.HasValue ? id.Value : 0;
            vm.filter_page = Get_SearchPagination_Params(ctrl, vm);

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

        private SearchPaginationViewModel Get_SearchPagination_Params(Controller ctrl, ArtGalleryViewModel vm)
        {
            SearchPaginationViewModel filter_page = new SearchPaginationViewModel();
            filter_page.page = ctrl.Request["page"] == null ? 1 : Int32.Parse(ctrl.Request["page"].ToString());
            filter_page.filter = ctrl.Request["filter"] == null ? "" : ctrl.Request["page"].ToString();
            return filter_page;
        }

    }
}