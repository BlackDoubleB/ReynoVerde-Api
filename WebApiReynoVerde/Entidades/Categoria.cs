namespace WebApiReynoVerde.Entidades
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string NombreCategoria { get; set; }
        //Propiedad de navegación
        public List<Producto> Productos { get; set; }

    }
}
