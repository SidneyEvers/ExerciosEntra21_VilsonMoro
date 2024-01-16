using LojaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Data
{
    public class AplicacaoDbContext : DbContext
    {
        public AplicacaoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias_Table { get; set; }
        public DbSet<Produtos> Produtos_Table { get;set; }
    }
}
