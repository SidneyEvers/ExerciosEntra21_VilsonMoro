namespace ExercicioLinkedList.Models;

internal class CategoriaProduto
{ 

    static SortedList<CategoriaProduto, List<Produtos>> Lista = new();

    public int Id { get; set; }
    public string  Nome { get; set; }

    public CategoriaProduto(int id, string nome) {
        Id = id;    
        Nome = nome;
    }

    public void AdicionarProdutoNaLista(CategoriaProduto produtoCategoria, List<Produtos> lista)
    {
        Lista.Add(produtoCategoria, lista);
    }

    public void MostrarProdutoNaLista(List<Produtos> produtos)
    {
        var index = produtos.Count;

        foreach(KeyValuePair<CategoriaProduto, List<Produtos>> kv in Lista)
        {
            Console.WriteLine($"Categoria:\n{kv.Key.Nome}\nProdutos: ");
            
            for(int i = 0; i < index; i++)
            {
                Console.WriteLine($"{produtos[i].Nome}");
            }
        }
    }
   

}
