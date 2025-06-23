using WebApiReynoVerde.DTO;

namespace WebApiReynoVerde.Servicios
{
    public interface ICategoriaServicio
    {
        Task<List<CategoriaDTO>> ObtenerTodaCategoria();
        Task<CategoriaDTO> ObtenerCategoriaPorId(Guid id);
        Task<CategoriaDTO> CrearCategoria(CategoriaCrearDTO creacionDTO);
    }
}
