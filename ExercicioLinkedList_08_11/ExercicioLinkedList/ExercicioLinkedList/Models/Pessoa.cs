namespace ExercicioLinkedList.Models;

internal class Pessoa
{
    static SortedList<string, Pessoa> nomes = new();

    public Pessoa(string sobrenome)
    {
        Sobrenome = sobrenome;
    }

    public string Sobrenome { get; set; }

    public void AdicionarNaLista(string nome, Pessoa pessoa)
    {
        nomes.Add(nome, pessoa);
    }

    public void MostrarNaLista()
    {
        foreach (KeyValuePair<string, Pessoa> i in nomes)
        {
            Console.WriteLine($"Nome: {i.Key} Sobrenome: {i.Value.Sobrenome}");
        }
    }

}
