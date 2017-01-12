using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using website_negaheno.Areas.Admin.ViewModels;

namespace website_negaheno.DataAccessLayer
{
    public interface IServiceLayer
    {
        IDataRepository DataLayer { get; set; }

        GalleryPageViewModel Get_Index_ArtGalery(SearchPaginationViewModel search_pagination_vm);

    }
}
