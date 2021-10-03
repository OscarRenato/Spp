using Microsoft.AspNetCore.Mvc.Rendering;
using Spp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spp.API.Models
{
    public class ProyectoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Fondo")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Fondo.")]
        public int FondoId { get; set; }

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

        [DisplayName("Fecha Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime FIngreso { get; set; }

        [Display(Name = "Fecha Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime FIngresoLocal => FIngreso.ToLocalTime();

        [Display(Name = "Observacion")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }

        public IEnumerable<SelectListItem> Fondos { get; set; }

        //public TipoMonedaEnum TipoMonedaEnum { get; set; }

        //public TipoPagoEnum TipoPagoEnum { get; set; }

        //[Display(Name = "Tipo Moneda")]
        //public string TipoMonedaName { get; set; }

        //[Display(Name = "Tipo Financiamiento")]
        //public string TipoPagoName { get; set; }

        //[Display(Name = "Fondo Financiamiento")]
        //public string FondoName { get; set; }
    }
}
