using LojaAPI.Data.DTO.Categoria;
using LojaAPI.Data.DTO.Produtos;
using LojaAPI.Entities;
using LojaAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;


        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Produtos>>> ListarProdutos()
        {
            return Ok(await _produtoRepository.ListarProdutos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> ListarProdutosPeloId([FromRoute] int id)
        {
            return Ok(await _produtoRepository.ListarProdutosPeloId(id));
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarProdutos(AdicionarProdutosDto produtos)
        {
            
            if (produtos != null)
            {
                await _produtoRepository.AdicionarProdutosAsync(produtos);

                return Ok(produtos);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditarProdutos([FromRoute] int id, [FromBody] EditarProdutosDto request)
        {
            return Ok(await _produtoRepository.EditarProdutosAsync(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarProdutos([FromRoute] int id)
        {
            await _produtoRepository.DeletarProdutosAsync(id);
            return Ok();

        }
    }
}
