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


        [HttpGet("obtenerProductosFiltrados")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> ObtenerProductosFiltrados(
              [FromQuery] List<string>? categoria = null,
              [FromQuery] string? nombre = null
            ) 
        {
            var productos = await _productoServicio.ObtenerProductosFiltrados(categoria, nombre);
            if (productos is null || !productos.Any())
            {
                return NotFound(); 
            }
            return Ok(productos);
        }

        [HttpGet("obtenerProductosPrincipales")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> ObtenerProductosPrincipales()
        {
            var productos = await _productoServicio.ObtenerProductosPrincipales();
            if (productos is null || !productos.Any())
            {
                return NotFound(); 
            }
            return Ok(productos); 
        }
        [HttpGet("obtenerProductoPorId/{id}")]
        [Authorize]
        public async Task<ActionResult<ProductoDTO>> ObtenerProductoPorId(Guid id)
        {
            var producto = await _productoServicio.ObtenerProductoPorId(id);
            if (producto is null)
            {
                return NotFound(); 
            }
            return Ok(producto); 
        }

    }
}
