using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website_negaheno.Areas.Admin.ViewModels
{
    public class SearchPaginationViewModel
    {
        public string filter { get; set; }
        public int? page { get; set; }
    }
}