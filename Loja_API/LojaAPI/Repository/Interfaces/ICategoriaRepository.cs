using LojaAPI.Data.DTO.Categoria;
using LojaAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Repository.Interfaces;

public interface ICategoriaRepository
{
    Task<IReadOnlyList<Categoria>> ListarCategorias();
    Task<Categoria> ListarCategoriasPeloId(int id);
    Task<Categoria> AdicionarCategoriaAsync(Categoria categoria);
    Task<Categoria> EditarCategoriaAsync(int id,EditarCategoriaDto editarCategoriaDto);
    Task<string> DeletarCategoriaAsync(int id);
}
