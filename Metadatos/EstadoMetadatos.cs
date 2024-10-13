using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1.Models
{
    [MetadataType(typeof(EstadoMetadatos))]
    public partial class Estado
    {

    }
    public class EstadoMetadatos
    {
        [Display(Name = "Estado")]
        public string descripcion { get; set; }

    }
}