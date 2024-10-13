using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1.Models
{
    [MetadataType(typeof(AutorMetadatos))]
    public partial class Autor
    {
        public string nombreCompleto { get { return $"{nombre} {apellido}"; } }
    }
    public class AutorMetadatos
    {
        [Display(Name = "Nombre")]
        [Required]
        [MaxLength(50, ErrorMessage ="El nombre no puede superar los 50 caracteres")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        [MaxLength(50)]
        public string apellido { get; set; }
        [Required]
        public int id_pais { get; set; }
        public bool estado { get; set; }

        [Display(Name = "Autor")]
        public string nombreCompleto { get { return $"{nombre} {apellido}"; } }
    }
}