using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Repositorios
{
    public interface IProductoRepositorio
    {
        Task<List<Producto>> ObtenerTodoProducto();
        Task<List<Producto>> ObtenerProductosPorCategoria(string categoria);
        Task<List<Producto>> ObtenerProductosPorNombre(string nombre);
       
    }
}
