using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_negaheno.Models
{
    public class tbl_art_gallery
    {
        [Key]
        public int ID { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [StringLength(200)]
        public string english_title { get; set; }

        public string description { get; set; }

        [StringLength(10)]
        public string fromDate { get; set; }

        [StringLength(10)]
        public string toDate { get; set; }

        [StringLength(5)]
        public string fromHour { get; set; }

        [StringLength(5)]
        public string toHour { get; set; }
    }
}