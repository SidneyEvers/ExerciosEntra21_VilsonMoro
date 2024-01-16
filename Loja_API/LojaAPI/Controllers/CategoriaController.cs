using LojaAPI.Data.DTO.Categoria;
using LojaAPI.Entities;
using LojaAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _repository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> ListarCategorias()
        {
            return Ok(await _repository.ListarCategorias());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> ListarCategoriasPeloId([FromRoute] int id)
        {
            return Ok(await _repository.ListarCategoriasPeloId(id));
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarCategoria(Categoria categoria)
        {
            if(categoria != null)
            {
                await _repository.AdicionarCategoriaAsync(categoria);

                return Ok(categoria);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditarCategoria([FromRoute] int id, [FromBody] EditarCategoriaDto request)
        {
            return Ok(await _repository.EditarCategoriaAsync(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarCategoria([FromRoute] int id)
        {
           await _repository.DeletarCategoriaAsync(id);
           return Ok();

        }
    }
}
