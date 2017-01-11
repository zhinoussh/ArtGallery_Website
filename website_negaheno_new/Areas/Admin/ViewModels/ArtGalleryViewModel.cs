using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_negaheno.Areas.Admin.ViewModels
{
    public class ArtGalleryViewModel
    {

        public int rowNumber { get; set; }
        public int GaleeryId { get; set; }
        public string eng_title { get; set; }
        [Required]
        public string fa_title { get; set; }
        public string description { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string fromHour { get; set; }
        public string toHour { get; set; }
    }
}