using EntityProjectNew.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityProjectNew.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Compromisso> Compromissos { get; set; }
    }
}
