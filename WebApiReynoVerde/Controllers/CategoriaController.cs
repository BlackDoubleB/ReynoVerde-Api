using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public CategoriaController(ICategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }


        [HttpGet("{id:guid}", Name = "ObtenerCategoriaPorId")] // <<-- Este es el nombre de la ruta
        [Authorize]
        public async Task<ActionResult<CategoriaDTO>> ObtenerCategoriaPorId(Guid id)
        {
            var categoria = await _categoriaServicio.ObtenerCategoriaPorId(id);
            if (categoria is null)
            { 
                return NotFound(); // Retorna 404 si no se encuentra la categoría
            }
            return Ok(categoria); // Retorna 200 OK con la categoría encontrada
        }

        [HttpPost("crearcategoria")]
        [Authorize]
        public async Task<IActionResult> CrearCategoria([FromBody] CategoriaCrearDTO categoriaCrearDTO)
        {
            var nuevaCategoria = await _categoriaServicio.CrearCategoria(categoriaCrearDTO);
            return CreatedAtRoute("ObtenerCategoriaPorId", new { id = nuevaCategoria.Id }, nuevaCategoria);
        }
    }
}
