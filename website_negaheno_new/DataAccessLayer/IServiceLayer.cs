using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using website_negaheno.Areas.Admin.ViewModels;

namespace website_negaheno.DataAccessLayer
{
    public interface IServiceLayer
    {
        IDataRepository DataLayer { get; set; }

        GalleryPageViewModel Get_Index_ArtGallery(SearchPaginationViewModel search_pagination_vm);

        ArtGalleryViewModel Get_Insert_New_Gallery(int? id, Controller ctrl);
        IPagedList<ArtGalleryViewModel> Post_Insert_New_Gallery(ArtGalleryViewModel vm);

        ArtGalleryViewModel Get_Delete_Gallery(int? id, Controller ctrl);

        IPagedList<ArtGalleryViewModel> Post_Delete_Gallery(ArtGalleryViewModel vm);

    }
}
