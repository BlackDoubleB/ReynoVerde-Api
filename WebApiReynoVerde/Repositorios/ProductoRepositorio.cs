using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> ObtenerProductosPrincipales()
        {
            return await _context.Producto
                        .Include(p => p.Categoria)
                        .GroupBy(p => p.CategoriaId)
                        .Select(g => g.First()) 
                        .Take(3)
                        .ToListAsync();
        }

        public async Task<List<Producto>> ObtenerProductosFiltrados(List<string>? categorias = null, string? nombre = null)
        {
            var query = _context.Producto
                     .Include(p => p.Categoria)
                     .AsQueryable();

            if (categorias != null && categorias.Any())
            {
                query = query.Where(p => categorias.Contains(p.Categoria.NombreCategoria));
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(p => p.ProductoNombre.Contains(nombre));
            }

            return await query.ToListAsync();
        }

        public async Task<Producto> ObtenerProductoPorId(Guid id)
        {
           var query = _context.Producto.Include(p => p.Categoria)
                        .Include(p => p.Stock)
                        .AsQueryable();

            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
