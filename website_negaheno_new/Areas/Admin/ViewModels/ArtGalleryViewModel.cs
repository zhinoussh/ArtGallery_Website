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
       
        [Display(Name = "English Title: ")]
        public string eng_title { get; set; }
        [Required]
        [Display(Name = "Farsi Title: ")]
        public string fa_title { get; set; }
        
        [Display(Name = "Description: ")]
        public string description { get; set; }
        
        [Display(Name = "Date: From ")]
        public string fromDate { get; set; }
        
        [Display(Name = "To ")]
        public string toDate { get; set; }
       
        [Display(Name = "Time: From ")]
        public string fromHour { get; set; }
        
        [Display(Name="To ")]
        public string toHour { get; set; }
    }
}