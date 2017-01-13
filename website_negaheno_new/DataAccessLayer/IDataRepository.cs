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
    }
}
