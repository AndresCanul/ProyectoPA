//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoApi_Martes.Models
{
    using System;
    
    public partial class ConsultarCarrito_Result
    {
        public long ConsecutivoCarrito { get; set; }
        public long ConsecutivoUsuario { get; set; }
        public long ConsecutivoProducto { get; set; }
        public System.DateTime FechaCarrito { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> Impuesto { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string Nombre { get; set; }
    }
}
