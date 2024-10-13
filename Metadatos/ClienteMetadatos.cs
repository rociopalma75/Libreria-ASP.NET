using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1.Models
{
    [MetadataType(typeof(ClienteMetadatos))]
    public partial class Cliente
    {
        public string nombreCompleto { get { return $"{nombre} {apellido}"; } }
    }
    public class ClienteMetadatos
    {
        [Required, MaxLength(50)]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        [Required, MaxLength(50)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Required, MaxLength(100)]
        [Display(Name ="Dirección")]
        public string direccion { get; set; }
        [Required, MaxLength(150), EmailAddress]
        [Display(Name = "Mail")]
        public string correo { get; set; }
        public bool estado { get; set; } = true;
        [Display(Name = "N° de Libros")]
        public int cant_libros_prestados { get; set; }
        [Display(Name = "Cliente")]
        public string nombreCompleto { get { return $"{nombre} {apellido}"; } }

    }
}