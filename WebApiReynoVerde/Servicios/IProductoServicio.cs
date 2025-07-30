using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Servicios
{
    public interface IProductoServicio
    {
      
       
        Task<List<ProductoDTO>> ObtenerProductosFiltrados(List<string> categoria = null, string? nombre = null);
        Task<List<ProductoDTO>> ObtenerProductosPrincipales();
    }
}
