using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Repositorios
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> ObtenerTodaCategoria();
        Task<Categoria> ObtenerCategoriaPorId(Guid id);
       
    }
}
