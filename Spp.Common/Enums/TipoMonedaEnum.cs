using System.ComponentModel.DataAnnotations;

namespace Spp.Common.Enums
{
    public enum TipoMonedaEnum
    {
        [Display(Name = "DOLLAR USA")]
        Dollar = 10,

        [Display(Name = "NUEVOS SOLES")]
        Soles = 11
    }
}
