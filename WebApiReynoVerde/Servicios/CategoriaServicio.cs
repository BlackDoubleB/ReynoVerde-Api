using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Entidades;
using WebApiReynoVerde.Repositorios;

namespace WebApiReynoVerde.Servicios
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaServicio(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

      
        public async Task<CategoriaDTO> ObtenerCategoriaPorId(Guid id)
        {
            var categoriaEntidad = await _categoriaRepositorio.ObtenerCategoriaPorId(id);
            if (categoriaEntidad == null)
            { 
            return null;
            }
            var categoriasDTO = new CategoriaDTO
            {
                Id = categoriaEntidad.Id,
                NombreCategoria = categoriaEntidad.NombreCategoria
            };
            return categoriasDTO;
        }

        public async Task<List<CategoriaDTO>> ObtenerTodaCategoria()
        {
            var categoriaEntidad = await _categoriaRepositorio.ObtenerTodaCategoria();

            if (categoriaEntidad == null || !categoriaEntidad.Any())
            {
                return new List<CategoriaDTO>();
            }

            var categoriasDTO = categoriaEntidad.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                NombreCategoria = c.NombreCategoria
            }).ToList();

            return categoriasDTO;
        }
    }
}
