namespace Desafio_Loja_Aula49.Models;

internal class Categoria
{
    private string? insertCategoria;

    public int Id { get; set; }
    public string Descricao { get; set; }

    public Categoria(int id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }

    public Categoria(string? insertCategoria)
    {
        this.insertCategoria = insertCategoria;
    }

    public Categoria()
    {
    }

    public string ToString()
    {
        return $"{Id} {Descricao}";
    }

}
