using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace website_negaheno.Models
{
    public class tbl_art_gallery
    {
        public tbl_art_gallery()
        {
            photos = new HashSet<tbl_art_galery_photo>();
        }

        [Key]
        public int ID { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [StringLength(200)]
        public string english_title { get; set; }

        public string description { get; set; }

        [StringLength(20)]
        public string fromDate { get; set; }

        [StringLength(20)]
        public string toDate { get; set; }

        [StringLength(5)]
        public string fromHour { get; set; }

        [StringLength(5)]
        public string toHour { get; set; }

        public virtual ICollection<tbl_art_galery_photo> photos{ get; set; }
    }
}