using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI_Simplificada.Data;
using LojaAPI_Simplificada.Entities;
using LojaAPI_Simplificada.Dto;
using LojaAPI_Simplificada.Config;

namespace LojaAPI_Simplificada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public UsersController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusuarios_Table()
        {
          if (_context.usuarios_Table == null)
          {
              return NotFound();
          }
            return await _context.usuarios_Table.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.usuarios_Table == null)
          {
              return NotFound();
          }
            var user = await _context.usuarios_Table.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.usuarios_Table == null)
          {
              return Problem("Entity set 'ApiDbContext.usuarios_Table'  is null.");
          }
            _context.usuarios_Table.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> login(userDto userDto)
        {
            string token = "";
            var users = await _context.usuarios_Table.ToListAsync();
            var userLogado = (from u in users
                              where u.Username == userDto.Username & u.Password == userDto.Password
                              select u).ToList();

            if (userLogado is not null)
            {
                token = TokenService.GenerateToken(userLogado[0]);
            }

            return new
            {
                token = token
            };
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.usuarios_Table == null)
            {
                return NotFound();
            }
            var user = await _context.usuarios_Table.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.usuarios_Table.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.usuarios_Table?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
