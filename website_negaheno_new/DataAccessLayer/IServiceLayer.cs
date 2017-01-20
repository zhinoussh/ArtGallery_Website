using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using website_negaheno.Areas.Admin.ViewModels;
using website_negaheno.Areas.Website.ViewModels;

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

        PhotoAlbumViewModel Get_PhotoAlbum_Images(int? page,Controller ctrl);
        void Post_AddPhotoAlbumImage(HttpPostedFileBase image, Controller ctrl);
        ImageViewModel Get_Delete_PhotoAlbumImage(string img_path, Controller ctrl);
        void Post_Delete_PhotoAlbumImage(int id, Controller ctrl);

        /******WEBSITE AREA***************/
        HomePageViewModel Get_HomePage();
        GalleryDetailPageViewModel Get_GalleryDetail_Page(int id);
        IPagedList<GalleryDetailViewModel> Get_PreviousGalleryList(int? page);

        List<string> Get_PhotoGAllery();
 
    }
}
