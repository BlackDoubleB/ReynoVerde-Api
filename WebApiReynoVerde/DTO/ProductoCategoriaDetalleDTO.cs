namespace WebApiReynoVerde.DTO
{
    public class ProductoCategoriaDetalleDTO
    {
        public Guid Id { get; set; }
        public string CategoriaNombre { get; set; }
        public string ProductoNombre { get; set; }
        public string ProductoDescripcion { get; set; } 
        public string ImagenUrl { get; set; }
        public float Precio { get; set; }
        public int CantidadStock { get; set; }
    }
}
