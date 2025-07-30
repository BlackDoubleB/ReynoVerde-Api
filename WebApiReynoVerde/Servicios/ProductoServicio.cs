using Microsoft.AspNetCore.Mvc;
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


        public async Task<List<ProductoDTO>> ObtenerProductosFiltrados(List<string>? categorias = null, string? nombre = null)
        {
            var productosEntidad = await _productoRepositorio.ObtenerProductosFiltrados(categorias, nombre);

            if (productosEntidad?.Any() != true) return new List<ProductoDTO>();

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

        public async Task<List<ProductoDTO>> ObtenerProductosPrincipales()
        {
            var productosEntidad = await _productoRepositorio.ObtenerProductosPrincipales();
            if (productosEntidad?.Any() != true) return new List<ProductoDTO>();
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
