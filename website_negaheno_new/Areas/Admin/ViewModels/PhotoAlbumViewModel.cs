using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_negaheno.Areas.Admin.ViewModels
{
    public class PhotoAlbumViewModel
    {
        public HttpPostedFileBase image { get; set; }
        public string photo_path { get; set; }
        public int page { get; set; }
        public IPagedList<string> photos { get; set; }
    }
}