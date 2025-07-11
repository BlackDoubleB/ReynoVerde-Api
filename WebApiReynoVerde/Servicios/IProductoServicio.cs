using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Servicios
{
    public interface IProductoServicio
    {
      
        Task<List<ProductoDTO>> ObtenerTodoProducto();
        Task<List<ProductoDTO>> ObtenerProductosPorCategoria(string categoria);
        Task<List<ProductoDTO>> ObtenerProductosPorNombre(string nombre);
    }
}
