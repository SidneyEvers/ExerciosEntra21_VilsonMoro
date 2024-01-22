using Autenticao.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticao.Data;

public class AuthContext : DbContext
{
    public AuthContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> usuarios { get; set; }

}
