using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_negaheno
{
    public class ArtGalleryViewModel
    {

        public int rowNumber { get; set; }

        public SearchPaginationViewModel filter_page { get; set; }
        
        public int GalleryId { get; set; }
       
        [Display(Name = "English Title: ")]
        [MaxLength(200,ErrorMessage="max lenghts should be 200 characters")]
        public string eng_title { get; set; }
       
        [Required(ErrorMessage="Please Enter the Title of Gallery.")]
        [MaxLength(200, ErrorMessage = "max lenghts should be 200 characters")]
        [Display(Name = "Farsi Title: ")]
        public string fa_title { get; set; }
        
        [Display(Name = "Description:")]
        public string description { get; set; }
        
        [Display(Name = "From")]
        public string fromDate { get; set; }
        
        [Display(Name = "To")]
        public string toDate { get; set; }
       
        [Display(Name = "Time:")]
        [MaxLength(5, ErrorMessage = "max lenghts should be 5 characters")]
        public string fromHour { get; set; }
        
        [Display(Name="To")]
        [MaxLength(5, ErrorMessage = "max lenghts should be 5 characters")]
        public string toHour { get; set; }
    }
}