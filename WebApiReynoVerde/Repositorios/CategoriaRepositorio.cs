using Microsoft.EntityFrameworkCore;
using WebApiReynoVerde.Entidades;

namespace WebApiReynoVerde.Repositorios
{
    public class CategoriaRepositorio:ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepositorio(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Categoria> ObtenerCategoriaPorId(Guid id)
        {
           return await _context.Categoria.FindAsync(id);
        }

        public async Task<List<Categoria>> ObtenerTodaCategoria()
        {
            return await _context.Categoria.ToListAsync();
        }
    }
}
