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
    public class CategoriasController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CategoriasController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        [Authorize(Roles ="empregado, gerente, admin")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias_Tables()
        {
          
            return await _context.Categorias_Tables.ToListAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
          if (_context.Categorias_Tables == null)
          {
              return NotFound();
          }
            var categoria = await _context.Categorias_Tables.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        [Authorize(Roles ="gerente,admin")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categorias
        [HttpPost]
        [Authorize(Roles ="gerente,admin")]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias_Tables.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias_Tables.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias_Tables.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return (_context.Categorias_Tables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
