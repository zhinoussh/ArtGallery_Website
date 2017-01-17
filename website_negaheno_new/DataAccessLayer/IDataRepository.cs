using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using website_negaheno.Areas.Admin.ViewModels;

namespace website_negaheno.DataAccessLayer
{
    public interface IDataRepository
    {
        List<ArtGalleryViewModel> Get_ArtGalleryList();
        void Insert_New_ArtGallery(ArtGalleryViewModel vm);
        void Delet_ArtGallery(int galleryId);
        ArtGalleryViewModel get_ArtGallery_byID(int id);

        List<string> get_gallery_images(int id);
        void save_gallery_image(int galleryId,string img_path);
        string get_lastPhoto_path(int galleryId);
        ImageViewModel get_photo_by_path(string img_path);
        string delete_gallery_image(int id);
    }
}
