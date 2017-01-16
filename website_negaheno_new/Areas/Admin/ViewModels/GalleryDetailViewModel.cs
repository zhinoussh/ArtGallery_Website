using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_negaheno.Areas.Admin.ViewModels
{
    public class GalleryDetailViewModel
    {
        public string eng_title { get; set; }
        public string fa_title { get; set; }
        public string description { get; set; }
        public string poster_path { get; set; }
        public string openning_hours { get; set; }
        public string visit_from { get; set; }
        public string visit_to { get; set; }

    }
}