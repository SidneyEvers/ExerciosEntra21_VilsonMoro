namespace ExercicioLinkedList.Models;

internal class CategoriaProduto
{ 

    static SortedList<CategoriaProduto, List<Produtos>> lista = new();

    public int Id { get; set; }
    public string  Nome { get; set; }

    public CategoriaProduto(int id, string nome) {
        Id = id;    
        Nome = nome;
    }

    public void AdicionarProdutoNaCategoria(CategoriaProduto produtoCategoria)
    {
        
    }
   

}
