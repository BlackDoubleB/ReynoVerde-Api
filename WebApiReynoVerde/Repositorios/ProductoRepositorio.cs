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

        public Task<List<Producto>> ObtenerProductosPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> ObtenerProductosPorCategoria(string categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> ObtenerTodoProducto()
        {
            return await _context.Producto
                                           .Include(p => p.Categoria)
                                           .Include(p => p.Stock)
                                           .ToListAsync();
        }
    }
}
