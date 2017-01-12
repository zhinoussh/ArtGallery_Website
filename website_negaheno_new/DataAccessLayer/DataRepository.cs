using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_negaheno.Areas.Admin.ViewModels;

namespace website_negaheno.DataAccessLayer
{
    public class DataRepository:IDataRepository
    {
        NegaheNoDB db;
        public DataRepository(NegaheNoDB _dbcontext)
        {
            db = _dbcontext;
        }

        public List<ArtGalleryViewModel> Get_ArtGalleryList()
        {
            List<ArtGalleryViewModel> lst_gallery = (from g in db.tbl_art_gallery
                                                     select new ArtGalleryViewModel
                                                     {
                                                         GaleeryId=g.ID,
                                                         fa_title = g.title,
                                                         eng_title = g.english_title,
                                                         fromDate = g.fromDate,
                                                         toDate = g.toDate,
                                                         fromHour = g.fromHour,
                                                         toHour = g.toHour,
                                                     }).ToList();

            return lst_gallery;
        }

        public void Insert_New_ArtGallery(Areas.Admin.ViewModels.ArtGalleryViewModel vm)
        {
        }

        public void Delet_ArtGallery(int galleryId)
        {
        }
    }
}