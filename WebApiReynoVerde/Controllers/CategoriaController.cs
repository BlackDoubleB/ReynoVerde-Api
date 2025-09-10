using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiReynoVerde.DTO;
using WebApiReynoVerde.Servicios;

namespace WebApiReynoVerde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServicio _categoriaServicio;
        private readonly ICategoriaProductoInicioServicio _categoriaProductoInicioServicio;

        public CategoriaController(ICategoriaServicio categoriaServicio, ICategoriaProductoInicioServicio categoriaProductoInicioServicio)
        {
            _categoriaServicio = categoriaServicio;
            _categoriaProductoInicioServicio = categoriaProductoInicioServicio;
        }


        [HttpGet("{id:guid}", Name = "ObtenerCategoriaPorId")] 
        [Authorize]
        public async Task<ActionResult<CategoriaDTO>> ObtenerCategoriaPorId(Guid id)
        {
            var categoria = await _categoriaServicio.ObtenerCategoriaPorId(id);
            if (categoria is null)
            {
                return NotFound(); 
            }
            return Ok(categoria); 
        }

        [HttpPost("crearcategoria")]
        [Authorize]
        public async Task<IActionResult> CrearCategoria([FromBody] CategoriaCrearDTO categoriaCrearDTO)
        {
            var nuevaCategoria = await _categoriaServicio.CrearCategoria(categoriaCrearDTO);
            return CreatedAtRoute("ObtenerCategoriaPorId", new { id = nuevaCategoria.Id }, nuevaCategoria);
        }


        [HttpGet("ObtenerTodaCategoria")]
        [Authorize]
        public async Task<IActionResult> ObtenerTodaCategoria()
        {
            var categorias = await _categoriaServicio.ObtenerTodaCategoria();

            if (categorias == null || !categorias.Any())
            {
                return NotFound("No se encontraron categorías.");
            }

            return Ok(categorias);
        }

        [HttpGet("ObtenerCategoriaProductoInicio")]
        [Authorize]
        public async Task<IActionResult> ObtenerCategoriaProductoInicio()
        {
            var categoriasProducto = await _categoriaProductoInicioServicio.ObtenerTodaCategoriaProductoInicio();
            if (categoriasProducto == null || !categoriasProducto.Any()) { 
            return NotFound("No se encontraron categorías de productos para inicio.");
            }
            return Ok(categoriasProducto);
        }
    }
}
