using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Servicios
{
    public interface ICategoriaProductoInicioServicio
    {
        Task<List<CategoriaProductoInicioDTO>> ObtenerTodaCategoriaProductoInicio();
    }
}
