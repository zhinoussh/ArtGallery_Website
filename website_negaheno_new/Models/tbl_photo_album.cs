using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace website_negaheno.Models
{
    public class tbl_photo_album
    {
        [Key]
        public int ID { get; set; }
        public string file_path { get; set; }
    }
}