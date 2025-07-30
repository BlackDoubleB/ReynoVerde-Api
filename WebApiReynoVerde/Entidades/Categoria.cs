namespace WebApiReynoVerde.Entidades
{
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; } 
        //Propiedad de navegación
        public List<Producto> Productos { get; set; }

    }
}
