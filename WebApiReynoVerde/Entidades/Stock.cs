namespace WebApiReynoVerde.Entidades
{
    public class Stock
    {
        public Guid Id { get; set; }
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }

        //Propiedad de navegación
        public Producto Producto { get; set; }

    }
}
