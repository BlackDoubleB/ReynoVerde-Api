using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Repositorios
{
    public interface ICategoriaProductoInicioRepositorio
    {
        Task<List<Producto>> ObtenerTodaCategoriaProductoInicio();
    }
}
