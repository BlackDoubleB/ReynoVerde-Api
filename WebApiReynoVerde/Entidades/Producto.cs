namespace WebApiReynoVerde.Entidades
{
    public class Producto
    {
        public Guid Id { get; set; }
        public Guid CategoriaId { get; set; }
        public string ProductoNombre { get; set; }
        public string ImagenUrl { get; set; }
        public float Precio { get; set; }
        public DateTime FechaRegistro { get; set; }
        //Propiedad de navegación
        public Categoria Categoria { get; set; }
        public List<DetalleVentaProducto> DetallesVentaProductoP { get; set; }
        public Stock Stock { get; set; }
    }
}
