namespace WebApiReynoVerde.DTO
{
    public class ProductoDTO
    {
        public Guid Id { get; set; }
        public string ProductoNombre { get; set; }
        public string ImagenUrl { get; set; }
        public float Precio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CategoriaNombre { get; set; } // Se obtiene desde Producto.Categoria.Nombre
        public int CantidadStock { get; set; } // Se obtiene desde Producto.Stock.Cantidad
    }
}
