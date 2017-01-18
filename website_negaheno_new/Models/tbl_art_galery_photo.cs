﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace website_negaheno.Models
{
    public class tbl_art_galery_photo
    {
        [Key]
        public int ID { get; set; }
        public string photo_path { get; set; }
        public int? GalleryID { get; set; }

        [ForeignKey("GalleryID")]
        public virtual tbl_art_gallery gallery { get; set; }
    }
}