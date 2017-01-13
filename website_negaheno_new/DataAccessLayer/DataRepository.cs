using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_negaheno.Areas.Admin.ViewModels;
using website_negaheno.Models;

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
                                                         GalleryId=g.ID,
                                                         fa_title = g.title,
                                                         eng_title = g.english_title,
                                                         fromDate = g.fromDate,
                                                         toDate = g.toDate,
                                                         fromHour = g.fromHour,
                                                         toHour = g.toHour,
                                                     }).ToList();

            return lst_gallery;
        }

        public ArtGalleryViewModel get_ArtGallery_byID(int id)
        {
            ArtGalleryViewModel result = new ArtGalleryViewModel();

            tbl_art_gallery gallery = db.tbl_art_gallery.Find(id);
            
            if (gallery != null)
            {
                result.GalleryId = id;
                result.fa_title = gallery.title;
                result.description = gallery.description;
                result.eng_title = gallery.english_title;
                result.fromDate = gallery.fromDate;
                result.toDate = gallery.toDate;
                result.fromHour = gallery.fromHour;
                result.toHour = gallery.toHour;
            }

            return result;
        }

        public void Insert_New_ArtGallery(ArtGalleryViewModel vm)
        {
            tbl_art_gallery gallery;
            if (vm.GalleryId == 0)
            {
                gallery = new tbl_art_gallery()
                {
                    description = vm.description,
                    title = vm.fa_title,
                    english_title = vm.eng_title,
                    fromDate = vm.fromDate,
                    toDate = vm.toDate,
                    fromHour = vm.fromHour,
                    toHour = vm.toHour
                };
                db.tbl_art_gallery.Add(gallery);
            }
            else
            {
                gallery = db.tbl_art_gallery.Find(vm.GalleryId);

                if (gallery != null)
                {
                    gallery.description = vm.description;
                    gallery.title = vm.fa_title;
                    gallery.english_title = vm.eng_title;
                    gallery.fromDate = vm.fromDate;
                    gallery.toDate = vm.toDate;
                    gallery.fromHour = vm.fromHour;
                    gallery.toHour = vm.toHour;
                }
            }
            db.SaveChanges();

        }

        public void Delet_ArtGallery(int galleryId)
        {
        }
    }
}