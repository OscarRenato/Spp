using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spp.Data.Entities
{
    public class Fondo
    {
        public int Id { get; set; }

        [Display(Name = "Empresa")]
        [Column(TypeName = "nvarchar(200)")]
        public string Empresa { get; set; }

        [Display(Name = "Direccion URL")]
        [Column(TypeName = "nvarchar(100)")]
        public string Web { get; set; }

        [Display(Name = "Telefono")]
        [Column(TypeName = "nvarchar(30)")]
        public string Telefonos { get; set; }

        [DisplayName("Correo electronico")]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Display(Name = "Direccion")]
        [Column(TypeName = "nvarchar(200)")]
        public string Direccion { get; set; }

        //public ICollection<Proyecto> Proyectos { get; set; }

    }
}
