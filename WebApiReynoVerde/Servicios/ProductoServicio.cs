using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Repositorios;
namespace WebApiReynoVerde.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IProductoRepositorio _productoRepositorio;
        public ProductoServicio(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }
        public Task<List<ProductoDTO>> ObtenerProductosPorCategoria(string categoria)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductoDTO>> ObtenerProductosPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductoDTO>> ObtenerTodoProducto()
        {
      

            var productosEntidad = await _productoRepositorio.ObtenerTodoProducto();
           
            if (productosEntidad?.Any() != true)
            {
                return new List<ProductoDTO>();
            }

            var productosDTO = productosEntidad.Select(p => new ProductoDTO
            {
                Id = p.Id,
                ProductoNombre = p.ProductoNombre,
                ImagenUrl = p.ImagenUrl,
                Precio = p.Precio,
                FechaRegistro = p.FechaRegistro,
                CategoriaNombre = p.Categoria?.NombreCategoria,
                CantidadStock = p.Stock?.Cantidad ?? 0
            }).ToList();

            return productosDTO;

        }
    }
}
