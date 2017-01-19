using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using website_negaheno.Areas.Admin.ViewModels;

namespace website_negaheno.Areas.Website.ViewModels
{
    public class HomePageViewModel
    {
        public List<ArtGalleryViewModel> lst_current_gallery{get; set;}
    }
}