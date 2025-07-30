using Microsoft.EntityFrameworkCore;
using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Repositorios
{
    public class CategoriaProductoInicioRepositorio : ICategoriaProductoInicioRepositorio
    {
        private readonly ApplicationDbContext _context;

        public CategoriaProductoInicioRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Producto>> ObtenerTodaCategoriaProductoInicio()
        {

            return await _context.Producto
                           .Include(p => p.Categoria)
                           .ToListAsync();
        }
    }
}
