using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_negaheno.Areas.Admin.ViewModels
{
    public class GalleryPageViewModel
    {
        public IPagedList paged_list_artGallery{ get; set; }

        public SearchPaginationViewModel search_pagination_params { get; set; }

    }
}