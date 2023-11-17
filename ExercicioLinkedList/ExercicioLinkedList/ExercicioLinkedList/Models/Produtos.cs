namespace ExercicioLinkedList.Models;

internal class Produtos
{
    private static List<Produtos> produtos = new List<Produtos>();

    public Produtos(string nome)
    {
        Nome = nome;
    }
    public string Nome { get; set; }

   
    

    public void AdicionarProduto(Produtos produto)
    {
        if(produtos.Contains(produto))
        {
            Console.WriteLine("Produto já existente");
            return;
        }
        else produtos.Add(produto);


    }
    public void MostrarProdutos()
    {
        foreach(var item in produtos)
        {
            Console.WriteLine($"Produto: {item.Nome}");
        }
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Produtos);
    }

    public bool Equals(Produtos other)
    {
        return other != null &&
               Nome == other.Nome;
    }

   /*public override int GetHashCode()
    {
        return HashCode.Combine(Nome);
    }
   */

}
