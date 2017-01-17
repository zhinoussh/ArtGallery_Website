using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_negaheno.Areas.Admin.ViewModels;
using PagedList;
using System.Web.Mvc;
using System.IO;

namespace website_negaheno.DataAccessLayer
{
    public class ServiceLayer:IServiceLayer
    {
        private IDataRepository _dataLayer;

        private const int pagesize = 10;
        private const int pagesize_image = 9;

        public IDataRepository DataLayer
        {
            get
            {
                if (_dataLayer == null)
                    _dataLayer = new DataRepository(new NegaheNoDB());

                return _dataLayer;
            }
            set
            {
                _dataLayer = value;
            }
        }

        public GalleryPageViewModel Get_Index_ArtGallery(SearchPaginationViewModel search_pagination_vm,Controller ctrl)
        {
            ctrl.TempData["page"] = search_pagination_vm.page;
            ctrl.TempData["filter"] = search_pagination_vm.filter;

            GalleryPageViewModel page_vm = new GalleryPageViewModel();
            IPagedList<ArtGalleryViewModel> paged_list_artGallery = null;

            List<ArtGalleryViewModel> lst_gallery = DataLayer.Get_ArtGalleryList();

            if (lst_gallery != null && lst_gallery.Count > 0)
            {
                lst_gallery = FilterGalleryList(lst_gallery, search_pagination_vm.filter);

                lst_gallery = lst_gallery.Select((x, Index) => new ArtGalleryViewModel()
                                        {
                                            rowNumber = Index + 1,
                                            GalleryId = x.GalleryId,
                                            fa_title = x.fa_title,
                                            description = x.description,
                                            fromDate = x.fromDate,
                                            toDate = x.toDate,
                                            fromHour = x.fromHour,
                                            toHour = x.toHour
                                        }).ToList();



                int currentpage = search_pagination_vm.page.HasValue ? search_pagination_vm.page.Value : 1;
                paged_list_artGallery = lst_gallery.ToPagedList(currentpage, pagesize);
            }

            page_vm.paged_list_artGallery = paged_list_artGallery;
            page_vm.search_pagination_params = search_pagination_vm;

            return page_vm;
        }

        public ArtGalleryViewModel Get_Insert_New_Gallery(int? id, Controller ctrl)
        {
            int gallery_id = id.HasValue ? id.Value : 0;

            ArtGalleryViewModel vm;
            if (gallery_id == 0)
            {
                vm = new ArtGalleryViewModel();
                vm.fromHour = "16:00";
                vm.toHour = "20:00";
            }
            else
            {
                vm = DataLayer.get_ArtGallery_byID(gallery_id);
            }

            vm.filter_page = Get_SearchPagination_Params(ctrl);
            
            return vm;                 
        }

        public void Post_Insert_New_Gallery(ArtGalleryViewModel vm)
        {
            DataLayer.Insert_New_ArtGallery(vm);
        }

        public ArtGalleryViewModel Get_Delete_Gallery(int? id, Controller ctrl)
        {
            ArtGalleryViewModel vm = new ArtGalleryViewModel();
            vm.GalleryId = id.HasValue ? id.Value : 0;
            vm.filter_page = Get_SearchPagination_Params(ctrl);
            return vm;        
        }

        public void Post_Delete_Gallery(ArtGalleryViewModel vm)
        {
            DataLayer.Delet_ArtGallery(vm.GalleryId);
        }

        public GalleryImagesViewModel Get_PartialPoster(int id, Controller ctrl)
        {
            GalleryImagesViewModel vm = new GalleryImagesViewModel();

            ArtGalleryViewModel gallery=DataLayer.get_ArtGallery_byID(id);

            vm.GalleryID = id;
            vm.GalleryName = gallery.fa_title.Length>50 ? (gallery.fa_title.Substring(0,50)+"...") : gallery.fa_title;
            
            string poster_path="/Upload/gallery_" + vm.GalleryID+ "/poster.jpg";
            if(File.Exists(ctrl.Server.MapPath(@poster_path)))
                vm.image_path = poster_path +"?"+  DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            else
                vm.image_path = "/images/empty.gif?" + DateTime.Now.ToString("ddMMyyyyhhmmsstt");

            vm.filter_page = Get_SearchPagination_Params(ctrl);

            return vm;
        }
        public void Post_AddGalleryPoster(GalleryImagesViewModel vm, Controller ctrl) {
            
            if (vm.image != null)
            {
                    string save_dir = ctrl.Server.MapPath(@"~\Upload\gallery_" + vm.GalleryID);
                    if (!Directory.Exists(save_dir))
                        Directory.CreateDirectory(save_dir);

                    vm.image.SaveAs(save_dir + "\\poster.jpg");
            }
        }

        public GalleryDetailViewModel Get_PartialDetail(int id, Controller ctrl)
        {
            GalleryDetailViewModel vm = new GalleryDetailViewModel();

            ArtGalleryViewModel gallery = DataLayer.get_ArtGallery_byID(id);

            vm.fa_title = gallery.fa_title;
            vm.eng_title = gallery.eng_title;
            vm.openning_hours = gallery.fromHour + " - " + gallery.toHour;
            vm.visit_from = "Opening Day : "+gallery.fromDate ;
            vm.visit_to ="Continues to : "+gallery.toDate;

            string poster_path = "/Upload/gallery_" + gallery.GalleryId + "/poster.jpg";
            if (File.Exists(ctrl.Server.MapPath(@poster_path)))
                vm.poster_path = poster_path + "?" + DateTime.Now.ToString("ddMMyyyyhhmmsstt");
            else
                vm.poster_path = "/images/empty.gif?" + DateTime.Now.ToString("ddMMyyyyhhmmsstt");


            return vm;
        }


        public GalleryImagesViewModel Get_ArtGallery_Images(int id, int? page, Controller ctrl)
        {
            
            GalleryImagesViewModel vm = new GalleryImagesViewModel();

            int current_page = page.HasValue ? page.Value : 1;
            ctrl.TempData["page"] = current_page;

            List<string> str_images = DataLayer.get_gallery_images(id);

            for (int i=0;i<str_images.Count;i++)
            {
                str_images[i] = ("gallery_" + id + "/" + str_images[i]);
            }

            IPagedList<string> paged_list_images=null;
            if(str_images!=null)
            {
                paged_list_images = str_images.ToPagedList(current_page, pagesize_image);
            }

            vm.gallery_images =paged_list_images;
            vm.GalleryID = id;
            vm.filter_page = new SearchPaginationViewModel() { page = current_page };

            return vm;

        }
        public void Post_AddGalleryImage(GalleryImagesViewModel vm, Controller ctrl)
        {

            string file_name = "";
            string photo_name = DataLayer.get_lastPhoto_path(vm.GalleryID);
            if (photo_name != "")
            {
                int index_from = photo_name.LastIndexOf('_') + 1;
                int index_to = photo_name.LastIndexOf('.');
                int photo_num = Int32.Parse(photo_name.Substring(index_from, index_to - index_from)) + 1;
                file_name = vm.GalleryID + "_" + photo_num + ".jpg";
            }
            else
                file_name = vm.GalleryID + "_1.jpg";

            DataLayer.save_gallery_image(vm.GalleryID, file_name);

            string save_dir = ctrl.Server.MapPath(@"~\Upload\gallery_" + vm.GalleryID);
            if (!Directory.Exists(save_dir))
                Directory.CreateDirectory(save_dir);

            vm.image.SaveAs(save_dir + "\\" + file_name);
            
        }
        public ImageViewModel Get_Delete_GalleryImage(string img_path, Controller ctrl)
        {
            ImageViewModel photo = new ImageViewModel();

            if (!String.IsNullOrEmpty(img_path))
            {
                string filename = img_path.Split('/')[1];
                photo=DataLayer.get_photo_by_path(filename);
                photo.page = ctrl.TempData["page"] == null ? 1 : Int32.Parse(ctrl.TempData["page"].ToString());
            }

            return photo;
        }
        public void Post_Delete_GalleryImage(int id,Controller ctrl)
        {
             string file_path=DataLayer.delete_gallery_image(id);
             file_path = ctrl.Server.MapPath(@"~\Upload\" + file_path);
             if (File.Exists(file_path))
                 File.Delete(file_path);
        }

        private SearchPaginationViewModel Get_SearchPagination_Params(Controller ctrl)
        {
            SearchPaginationViewModel params_search_pagination = new SearchPaginationViewModel()
            {
                page = ctrl.TempData["page"] == null ? 1 : Int32.Parse(ctrl.TempData["page"].ToString()),
                filter = ctrl.TempData["filter"] == null ? "" : ctrl.TempData["filter"].ToString()
            };

            return params_search_pagination;
        }

        private List<ArtGalleryViewModel> FilterGalleryList(List<ArtGalleryViewModel> lst_gallery,string filter)
        {
            if (!String.IsNullOrEmpty(filter))
                lst_gallery=lst_gallery.Where(x => (!String.IsNullOrEmpty(x.fa_title) && x.fa_title.Contains(filter))
                                     || (!String.IsNullOrEmpty(x.eng_title) && x.eng_title.Contains(filter))
                                     || (!String.IsNullOrEmpty(x.fromDate) && x.fromDate.Contains(filter))
                                     || (!String.IsNullOrEmpty(x.toDate) && x.toDate.Contains(filter))
                                     ).ToList();

            return lst_gallery;
                                     
        }

    }
}