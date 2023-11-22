using Desafio_Loja_Aula49.Models;

namespace Desafio_Loja_Aula49.Interfaces;

interface ICrud<T>
{
    public bool salvar(T t);
    public void listar();
    public void editar(T t);
    public void excluir(int id);

}
