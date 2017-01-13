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

        public void Insert_New_ArtGallery(ArtGalleryViewModel vm)
        {
            tbl_art_gallery gallery;
            if (vm.GaleeryId == 0)
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
                gallery = db.tbl_art_gallery.Find(vm.GaleeryId);

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