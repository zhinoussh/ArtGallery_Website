using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_negaheno.Areas.Admin.ViewModels;
using PagedList;

namespace website_negaheno.DataAccessLayer
{
    public class ServiceLayer:IServiceLayer
    {
        private IDataRepository _dataLayer;

        private const int pagesize=10;

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

        public GalleryPageViewModel Get_Index_ArtGalery(SearchPaginationViewModel search_pagination_vm)
        {
            GalleryPageViewModel page_vm = new GalleryPageViewModel();

            List<ArtGalleryViewModel> lst_gallery = DataLayer.Get_ArtGalleryList();

            lst_gallery = lst_gallery.Select((x, Index) => new ArtGalleryViewModel()
            {
                rowNumber = Index + 1,
                GaleeryId = x.GaleeryId,
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
    }
}