using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autenticao.Data;
using Autenticao.Models;
using Microsoft.IdentityModel.Tokens;
using Autenticao.Config;
using Autenticao.DTO;
using Microsoft.AspNetCore.Identity;

namespace Autenticao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly AuthContext _context;

        public UsersController(AuthContext context)
        {
            _context = context;
            
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusuarios()
        {
            return await _context.usuarios.ToListAsync();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.usuarios.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Users
        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> login(userDto userDto)
        {
            string token = "";
            var users = await _context.usuarios.ToListAsync();
            var userLogado =  (from u in users 
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

        private bool UserExists(int id)
        {
            return _context.usuarios.Any(e => e.Id == id);
        }
    }
}
