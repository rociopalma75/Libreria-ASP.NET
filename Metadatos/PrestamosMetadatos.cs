using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Parcial1.Models
{
    [MetadataType(typeof(PrestamosMetadatos))]
    public partial class Prestamos
    {

    }
    public class PrestamosMetadatos
    {
        [Required]
        public int id_libro { get; set; }
        [Required]
        public int id_cliente { get; set; }
        [Required, Display(Name = "Fecha de Prestamo")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "2023-01-01 00:00:00", "2024-10-18 00:00:00")]
        public System.DateTime fecha_prestamo { get; set; }
        [DataType(DataType.DateTime), Display(Name = "Fecha de Devolución")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        //[Range(typeof(DateTime), "2023-01-01 00:00:00", "2024-10-18 00:00:00")]
        public Nullable<System.DateTime> fecha_devolucion { get; set; }
        [Required]
        public int id_estado { get; set; }
        public bool estado_eliminado { get; set; } = true;
    }
}