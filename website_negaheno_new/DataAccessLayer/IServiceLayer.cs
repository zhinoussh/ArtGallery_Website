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

        GalleryPageViewModel Get_Index_ArtGallery(SearchPaginationViewModel search_pagination_vm, Controller ctrl);

        ArtGalleryViewModel Get_Insert_New_Gallery(int? id,Controller ctrl);
        void Post_Insert_New_Gallery(ArtGalleryViewModel vm);

        ArtGalleryViewModel Get_Delete_Gallery(int? id, Controller ctrl);

        void Post_Delete_Gallery(ArtGalleryViewModel vm);

        GalleryImagesViewModel Get_PartialPoster(int id, Controller ctrl);
        void Post_AddGalleryPoster(GalleryImagesViewModel vm,Controller ctrl);
        GalleryDetailViewModel Get_PartialDetail(int id, Controller ctrl);

        GalleryImagesViewModel Get_ArtGallery_Images(int id,int? page, Controller ctrl);
        void Post_AddGalleryImage(GalleryImagesViewModel vm, Controller ctrl);
        ImageViewModel Get_Delete_GalleryImage(string img_path, Controller ctrl);
        void Post_Delete_GalleryImage(int id, Controller ctrl);
    }
}
