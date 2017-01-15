using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_negaheno.Areas.Admin.ViewModels
{
    public class GalleryImagesViewModel
    {
        public int GalleryID { get; set; }
        public HttpPostedFileBase image { get; set; }
        public string GalleryName { get; set; }
        public string image_path { get; set; }
    }
}