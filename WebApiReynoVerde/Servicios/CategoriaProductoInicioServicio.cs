

using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Repositorios;

namespace WebApiReynoVerde.Servicios
{
    public class CategoriaProductoInicioServicio : ICategoriaProductoInicioServicio
    {
        private readonly ICategoriaProductoInicioRepositorio _categoriaProductoRepositorio;
        public CategoriaProductoInicioServicio(ICategoriaProductoInicioRepositorio categoriaProductoRepositorio)
        {
            _categoriaProductoRepositorio = categoriaProductoRepositorio;
        }
        public async Task<List<CategoriaProductoInicioDTO>> ObtenerTodaCategoriaProductoInicio()
        {

            var productos = await _categoriaProductoRepositorio.ObtenerTodaCategoriaProductoInicio();
           
            if (productos == null || !productos.Any())
            {
                return new List<CategoriaProductoInicioDTO>(); 
            }
            var productosAgrupados = productos
               .GroupBy(p => p.Categoria.Id)
               .Select(g => g.OrderByDescending(p => p.FechaRegistro).First())
               .ToList();
            return productosAgrupados.Select(p => new CategoriaProductoInicioDTO
            {
                Id = p.Categoria.Id,
                DescripcionCategoria = p.Categoria.DescripcionCategoria,
                ImagenUrl = p.ImagenUrl, 
                NombreCategoria = p.Categoria.NombreCategoria 
            }).ToList();

        }
    }
}
