namespace WebApiReynoVerde.DTO
{
    public class VentaDTO
    {

        public Guid Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Metodo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal Total { get; set; }
    }
}
