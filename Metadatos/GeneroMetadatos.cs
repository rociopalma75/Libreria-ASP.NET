using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1.Models
{
    [MetadataType(typeof(GeneroMetadatos))]
    public partial class Genero
    {

    }
    public class GeneroMetadatos
    {
        [Display(Name = "Género")]
        public string descripcion { get; set; }
    }
}