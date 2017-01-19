using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_negaheno.Areas.Admin.ViewModels;

namespace website_negaheno.Areas.Website.ViewModels
{
    public class GalleryDetailPageViewModel
    {
        public List<string> photos { get; set; }
        public GalleryDetailViewModel accordion_detail { get; set; }
    }
}