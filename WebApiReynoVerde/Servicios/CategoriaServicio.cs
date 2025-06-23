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

        public async Task<CategoriaDTO> CrearCategoria(CategoriaCrearDTO creacionDTO)
        {
            // Paso 1: Realizar cualquier lógica de negocio o validación adicional
            // (Ej. verificar si el nombre ya existe, lo cual ya haces en el controlador,
            // pero el servicio podría tener validaciones más complejas)
            // Omitiendo ese paso aquí para simplificar el ejemplo.

            // Paso 2: Mapear el DTO de Creación a la Entidad de Dominio
            // Aquí creamos la entidad 'Laptop' a partir de los datos del DTO.
            // NOTA: El 'Id' NO se asigna aquí, porque será autogenerado por la BD.
            var categoriaEntidad = new Categoria
            {
                NombreCategoria = creacionDTO.NombreCategoria
            };

            // Paso 3: Llamar al Repositorio para guardar la entidad
            // Después de SaveChangesAsync(), el objeto 'laptopEntidad' contendrá el Id autogenerado.
            await _categoriaRepositorio.Crear(categoriaEntidad);

            // Paso 4: Mapear la Entidad de Dominio (ya con el Id generado) a un DTO de Respuesta
            // Ahora creamos el DTO que se devolverá al cliente, incluyendo el Id generado.
            var nuevaCategoriaDTO = new CategoriaDTO
            {
                Id = categoriaEntidad.Id,
                NombreCategoria = categoriaEntidad.NombreCategoria
            };

            // Paso 5: Devolver el DTO de Respuesta
            return nuevaCategoriaDTO;

        }

        public async Task<CategoriaDTO> ObtenerCategoriaPorId(Guid id)
        {
            var categoriaEntidad = await _categoriaRepositorio.ObtenerCategoriaPorId(id);
            if (categoriaEntidad == null)
            { 
            return null; // O lanzar una excepción si prefieres
            }
            var categoriaDTO = new CategoriaDTO
            {
                Id = categoriaEntidad.Id,
                NombreCategoria = categoriaEntidad.NombreCategoria
            };
            return categoriaDTO;
        }

        public Task<List<CategoriaDTO>> ObtenerTodaCategoria()
        {
            throw new NotImplementedException();
        }
    }
}
