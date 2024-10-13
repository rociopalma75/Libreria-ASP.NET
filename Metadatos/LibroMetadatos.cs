using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1.Models
{
    [MetadataType(typeof(LibroMetadatos))]
    public partial class Libro
    {

    }

    public class LibroMetadatos
    {
        [Required, Display(Name = "Título"), MaxLength(100)]
        public string titulo { get; set; }
        [Required, Range(1900, 2024), Display(Name = "Año de Publicación")]
        public int anio_publicacion { get; set; }
        [Required]
        public int id_autor { get; set; }
        [Required]
        public int id_genero { get; set; }
        public bool estado { get; set; } = true;
    }
}