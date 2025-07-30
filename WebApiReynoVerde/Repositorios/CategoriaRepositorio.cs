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

        public Task Actualizar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Crear(Categoria categoria)
        {
            try {
                _context.Add(categoria);
                int filasAfectadas = await _context.SaveChangesAsync();
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la categoría: {ex.Message}");
                return false;
            }
           
        }

        public Task Eliminar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria> ObtenerCategoriaPorId(Guid id)
        {
            // Busca la categoría por su Guid ID.
            // Si la categoría tiene propiedades de navegación que necesitas incluir (ej. una lista de Productos),
            // usarías .Include() aquí, similar al ejemplo de Ventas.
            return await _context.Categoria.FindAsync(id);
        }

        public async Task<List<Categoria>> ObtenerTodaCategoria()
        {
            return await _context.Categoria.ToListAsync();
        }
    }
}
