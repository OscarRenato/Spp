using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spp.Data.Entities
{
    public class Proyecto
    {
        public int Id { get; set; }

        [DisplayName("Proy Nro")]
        [Column(TypeName = "nvarchar(20)")]
        public string ProyectoNro { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Empresa { get; set; }

        [DisplayName("Empresa RUC")]
        [Column(TypeName = "nvarchar(20)")]
        public string EmpresaRuc { get; set; }

        [DisplayName("Empresa Tutor")]
        [Column(TypeName = "nvarchar(300)")]
        public string EmpresaRepresentante { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [DisplayName("Tipo Moneda")]
        public int TipoMoneda { get; set; }

        [DisplayName("Tipo Financiamiento")]
        public int TipoPago { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Comision { get; set; }

        [DisplayName("Fecha Contrato")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime FContrato { get; set; }

        [Display(Name = "Fecha Contrato")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime FContratoLocal => FContrato.ToLocalTime();

        [DisplayName("Direccion Financiera")]
        [Column(TypeName = "nvarchar(300)")]
        public string DireccionFinanc { get; set; }

        [DisplayName("Monto Final")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoFinal { get; set; }

        public int FondoId { get; set; }

        public Fondo Fondo { get; set; }

        [DisplayName("Fecha Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime FIngreso { get; set; }

        [Display(Name = "Fecha Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime FIngresoLocal => FIngreso.ToLocalTime();

        [Display(Name = "Observacion")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }
    }
}
