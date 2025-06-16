namespace WebApiReynoVerde.Entidades
{
    public class DetalleVentaProducto
    {
        public Guid Id { get; set; } 
        public Guid VentaId { get; set; } //Fk
        public Guid ProductoId { get; set; } //Fk
        public int Cantidad { get; set; }

        //Propiedad de navegación
        public Producto Producto { get; set; } //Propiedad de navegación y tipo de relacion
        public Venta Venta { get; set; } //Propiedad de navegación y tipo de relacion
     
    }
}
