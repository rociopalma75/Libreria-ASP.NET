using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1.Models
{
    [MetadataType(typeof(PaisMetadatos))]
    public partial class Pais
    {

    }
    public class PaisMetadatos
    {
        [Display(Name = "País")]
        public string descripcion { get; set; }

    }
}