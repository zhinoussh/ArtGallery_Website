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
            tbl_art_gallery gallery=db.tbl_art_gallery.Find(galleryId);
            if (gallery != null)
            {
                db.tbl_art_gallery.Remove(gallery);
                db.SaveChanges();
            }
        }

        public List<string> get_gallery_images(int id) {

            List<string> images = (from i in db.tbl_art_gallery_photo
                                where i.GalleryID == id
                                select i.photo_path).ToList();

            return images;
        }
        public void save_gallery_image(int galleryId, string img_path)
        {
            tbl_art_galery_photo photo = new tbl_art_galery_photo()
            {
                GalleryID=galleryId,
                photo_path=img_path
            };

            db.tbl_art_gallery_photo.Add(photo);
            db.SaveChanges();
        }
        public string get_lastPhoto_path(int galleryId) {

            string photo_path="";
            tbl_art_galery_photo last_photo=db.tbl_art_gallery_photo.Where(x => x.GalleryID == galleryId)
                                              .OrderByDescending(x => x.ID).FirstOrDefault();

            if (last_photo != null)
                photo_path = last_photo.photo_path;

            return photo_path;
        }
        public ImageViewModel get_photo_by_path(string img_path)
        {

            ImageViewModel vm = (from p in db.tbl_art_gallery_photo.Where(x => x.photo_path == img_path)
                                 select new ImageViewModel()
                                 {
                                     GalleryId = p.GalleryID.HasValue?p.GalleryID.Value:0,
                                     ImageId=p.ID
                                 }).FirstOrDefault();
            return vm;
        }
        public string delete_gallery_image(int id) {
           tbl_art_galery_photo photo=db.tbl_art_gallery_photo.Find(id);
           string filepath = "gallery_" + photo.GalleryID + "\\" + photo.photo_path;
           if (photo != null)
           {
               db.tbl_art_gallery_photo.Remove(photo);
               db.SaveChanges();
           }

           return filepath;
        }
        public ArtGalleryViewModel get_gallery_in_date(string dt)
        {
            ArtGalleryViewModel gallery = (from g in db.tbl_art_gallery
                                           where dt.CompareTo(g.toDate) <= 0 && dt.CompareTo(g.fromDate) >= 0
                                           select new ArtGalleryViewModel()
                                           {
                                               fa_title = g.title,
                                               eng_title = g.title,
                                               fromHour = g.fromHour,
                                               toHour = g.toHour,
                                               fromDate = g.fromDate,
                                               toDate = g.toDate,
                                               description = g.description
                                           }).FirstOrDefault();

            return gallery;
        }

    }
}