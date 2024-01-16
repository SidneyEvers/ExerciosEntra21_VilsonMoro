using LojaAPI.Data.DTO.Categoria;
using LojaAPI.Data.DTO.Produtos;
using LojaAPI.Entities;

namespace LojaAPI.Repository.Interfaces;

public interface IProdutoRepository
{
    Task<IReadOnlyList<Produtos>> ListarProdutos();
    Task<Produtos> ListarProdutosPeloId(int id);
    Task<AdicionarProdutosDto> AdicionarProdutosAsync(AdicionarProdutosDto produtos);
    Task<Produtos> EditarProdutosAsync(int id, EditarProdutosDto editarProdutosDto);
    Task<string> DeletarProdutosAsync(int id);
}
