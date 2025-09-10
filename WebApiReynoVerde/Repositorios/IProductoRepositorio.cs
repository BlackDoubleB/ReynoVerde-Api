using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<List<Producto>> ObtenerProductosFiltrados(List<string> categoria = null, string? nombre = null);
        Task<List<Producto>> ObtenerProductosPrincipales();
        Task<Producto> ObtenerProductoPorId(Guid id);

    }
}
