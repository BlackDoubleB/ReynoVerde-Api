using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Servicios;

namespace WebApiReynoVerde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;
        public ProductoController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet("obtenertodoproducto")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> ObtenerTodoProducto() {
            var productos =  await _productoServicio.ObtenerTodoProducto();
            if (productos is null || !productos.Any())
            {
                return NotFound(); // Retorna 404 si no se encuentran productos
            }
            return Ok(productos); // Retorna 200 OK con la lista de productos encontrados
        }
    }
}
