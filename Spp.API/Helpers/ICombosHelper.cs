using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Spp.API.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboGestors();
        IEnumerable<SelectListItem> GetComboFondos();
    }
}
