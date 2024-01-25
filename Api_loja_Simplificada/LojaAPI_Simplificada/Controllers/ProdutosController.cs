using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI_Simplificada.Data;
using LojaAPI_Simplificada.Entities;
using Microsoft.AspNetCore.Authorization;

namespace LojaAPI_Simplificada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ProdutosController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet("/api/[controller]/pages")]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetPagesProdutos(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize
            )
        {
            List<Produtos> produtos = await _context.Produtos_Table
                .AsNoTracking()
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .Include(c => c.Categoria)
                .ToListAsync();
            
            return produtos;
        }

        //api/produtos/filtro?descricao
        [HttpGet("/api/[controller]/filtro")]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutosByDescricao(
          [FromQuery] string descricao)
        {
            List<Produtos> lista = await _context.Produtos_Table.ToListAsync();
            var produtos = (from prod in lista
                            where prod.Nome.ToLower().Contains(descricao.ToLower())
                            select prod).ToList();

            foreach (Produtos produto in produtos)
            {
                produto.Categoria = await _context.Categorias_Tables.FirstOrDefaultAsync(c => c.Id == produto.CategoriaId);
            }
            return produtos;
        }

        // GET: api/Produtos
        [HttpGet]
        [Authorize(Roles = "empregado,gerente,admin")]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutos()
        {
            List<Produtos> produtos = await _context.Produtos_Table.ToListAsync();
            foreach (Produtos produto in produtos)
            {
                produto.Categoria = await _context.Categorias_Tables
                .FirstOrDefaultAsync(c => c.Id == produto.CategoriaId);
            }
            return produtos;
        }

        // GET: api/Produtos
        [HttpGet("/api/[controller]/categoria/{id}")]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProdutosByCategoria(
           [FromRoute] int id)
        {
            List<Produtos> produtos = await _context.Produtos_Table.ToListAsync();
            var prodByCategoria =
                (from prod in produtos
                 where prod.CategoriaId == id
                 select prod).ToList();

            Categoria categoria = await _context.Categorias_Tables.FirstOrDefaultAsync(c => c.Id == id);
            foreach (Produtos produto in prodByCategoria)
            {
                produto.Categoria = categoria;
            }
            return prodByCategoria;
        }


        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> GetProdutos(int id)
        {
            var produtos = await _context.Produtos_Table.FindAsync(id);

            if (produtos == null)
            {
                return NotFound();
            }

            return produtos;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles ="gerente,admin")]
        public async Task<IActionResult> PutProdutos(int id, Produtos produtos)
        {
            if (id != produtos.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produtos
        [HttpPost]
        [Authorize(Roles ="empregado,admin")]
        public async Task<ActionResult<Produtos>> PostProdutos(Produtos produtos)
        {
            produtos.CategoriaId = produtos.Categoria.Id;
            produtos.Categoria =
                await _context.Categorias_Tables
                .FirstOrDefaultAsync(c => c.Id == produtos.CategoriaId);

            _context.Produtos_Table.Add(produtos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutos", new { id = produtos.Id }, produtos);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("/delete/{id}")]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> DeleteProdutos(int id)
        {
            if (_context.Produtos_Table == null)
            {
                return NotFound();
            }
            var produtos = await _context.Produtos_Table.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.Produtos_Table.Remove(produtos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutosExists(int id)
        {
            return (_context.Produtos_Table?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
