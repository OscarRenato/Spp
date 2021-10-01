using System.ComponentModel.DataAnnotations;

namespace Spp.Common.Enums
{
    public enum TipoPagoEnum
    {
        [Display(Name = "COMPRA - VENTA")]
        CompraVenta = 10,

        [Display(Name = "PRESTAMO")]
        Prestamo = 11,

        [Display(Name = "FIANZA")]
        Fianza = 12

    }
}
