using LojaAPI.Data;
using LojaAPI.Data.DTO.Categoria;
using LojaAPI.Entities;
using LojaAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Repository.Repos;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AplicacaoDbContext _context;

    public CategoriaRepository(AplicacaoDbContext context)
    {
        _context = context;
    }

    public async Task<Categoria> AdicionarCategoriaAsync(Categoria categoria)
    {
        if(categoria != null)
        {
            await _context.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }
        return null;
    }

    public async Task<string> DeletarCategoriaAsync(int id)
    {
        var categoria = await _context.Categorias_Table.FirstOrDefaultAsync(x => x.Id == id);

        if(categoria != null)
        {
        _context.Remove(categoria);
        await _context.SaveChangesAsync();
        }
        return "Nao econtrado";
    }

    //public Task<ActionResult> EditarCategoria(Categoria categoria)
    //{
    //    var categoriaAntiga = _context.Categorias_Table.FirstOrDefaultAsync(x => x.Id == categoria.Id);

    //    if(categoriaAntiga != null)
    //    {

    //    }
    //}

    public async Task<Categoria> EditarCategoriaAsync(int id, EditarCategoriaDto editarCategoriaDto)
    {
        var categoria = await _context.Categorias_Table.FirstOrDefaultAsync(x => x.Id == id);

        if(categoria != null)
        {
            categoria.Nome = editarCategoriaDto.Nome;
            _context.SaveChanges();

            return categoria;
        }
        return null;
    }

    public async Task<IReadOnlyList<Categoria>> ListarCategorias()
    {
        return await _context.Categorias_Table.ToListAsync();
    }

    public async Task<Categoria> ListarCategoriasPeloId(int id)
    {
        if(id != null && id > 0)
        {
            //await _context.Categorias_Table.FindAsync(id);
            var categoria = await _context.Categorias_Table.FirstOrDefaultAsync(x => x.Id == id);

            if(categoria is not null)
            {
                return categoria;
            }
        }
        return null;
    }
}
