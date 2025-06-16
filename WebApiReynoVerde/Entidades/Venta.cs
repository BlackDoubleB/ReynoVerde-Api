using Microsoft.AspNetCore.Identity;

namespace WebApiReynoVerde.Entidades
{
    public class Venta
    {
        public Guid Id { get; set; }
        public string UsuarioId { get; set; } 
        public string Metodo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal Total { get; set; }

        //Propiedad de navegación
        public IdentityUser Usuario { get; set; } 
        public List<DetalleVentaProducto> DetallesVentaProductoV { get; set; }
    }
}
