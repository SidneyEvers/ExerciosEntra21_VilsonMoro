using LojaAPI_Simplificada.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI_Simplificada.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Categoria> Categorias_Tables { get; set; }
    public DbSet<Produtos> Produtos_Table { get; set; }

}
