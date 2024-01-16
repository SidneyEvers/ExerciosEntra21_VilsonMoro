using LojaAPI.Data;
using LojaAPI.Data.DTO.Produtos;
using LojaAPI.Entities;
using LojaAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Repository.Repos;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AplicacaoDbContext _context;
    public ProdutoRepository(AplicacaoDbContext context)
    {
        _context = context;
    }

    public async Task<AdicionarProdutosDto> AdicionarProdutosAsync(AdicionarProdutosDto adicionarProdutos)
    {
        if(adicionarProdutos != null)
        {
            var categoria = await _context.Categorias_Table.FirstOrDefaultAsync(x => x.Id == adicionarProdutos.Categoria);

            if(categoria != null)
            {
                var novoProduto = new Produtos
                {
                    Id = adicionarProdutos.Id,
                    Descricao = adicionarProdutos.Descricao,
                    Valor = adicionarProdutos.Valor,
                    Estoque = adicionarProdutos.Estoque,
                    Categoria = categoria
                };
            }

            await _context.AddAsync(adicionarProdutos);
            await _context.SaveChangesAsync();

            return adicionarProdutos;
        }
        return null;
    }

    public async Task<string> DeletarProdutosAsync(int id)
    {
        var produtos = await _context.Produtos_Table.FirstOrDefaultAsync(x => x.Id == id);

        if (produtos != null)
        {
            _context.Remove(produtos);
            await _context.SaveChangesAsync();
        }
        return "Nao econtrado";
    }
    

    public async Task<Produtos> EditarProdutosAsync(int id, EditarProdutosDto editarProdutosDto)
    {
        var produtos = await _context.Produtos_Table.FirstOrDefaultAsync(x => x.Id == id);

        if(produtos != null)
        {
            var categoria = _context.Categorias_Table.FirstOrDefault(x => x.Id == editarProdutosDto.Categoria);

            produtos.Descricao = editarProdutosDto.Descricao;
            produtos.Valor = editarProdutosDto.Valor;
            produtos.Estoque = editarProdutosDto.Estoque;
            produtos.Categoria = categoria;

            return produtos;
        }

        return null;
    }


    public async Task<IReadOnlyList<Produtos>> ListarProdutos()
    {
        return await _context.Produtos_Table.Include(x => x.Categoria).ToListAsync();
    }
    public async Task<Produtos> ListarProdutosPeloId(int id)
    {
        if (id != null && id > 0)
        {
            //await _context.Categorias_Table.FindAsync(id);
            var produtos = await _context.Produtos_Table.FirstOrDefaultAsync(x => x.Id == id);

            if (produtos is not null)
            {
                return produtos;
            }
        }
        return null;
    }
}
