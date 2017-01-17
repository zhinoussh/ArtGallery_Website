using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_negaheno.Areas.Admin.ViewModels
{
    public class ImageViewModel
    {
        public int ImageId { get; set; }
        public int GalleryId { get; set; }
        public int page { get; set; }
    }
}