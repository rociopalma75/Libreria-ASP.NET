//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parcial1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prestamos
    {
        public int id { get; set; }
        public int id_libro { get; set; }
        public int id_cliente { get; set; }
        public System.DateTime fecha_prestamo { get; set; }
        public Nullable<System.DateTime> fecha_devolucion { get; set; }
        public int id_estado { get; set; }
        public bool estado_eliminado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Libro Libro { get; set; }
    }
}