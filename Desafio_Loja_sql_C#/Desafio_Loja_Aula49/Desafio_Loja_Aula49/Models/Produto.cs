namespace Desafio_Loja_Aula49.Models;

internal class Produto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public float Valor{ get; set; }
    public  int Categoria { get; set; }

    public Produto()
    {

    }
    public Produto(int id, string descricao, int quantidade, float valor, int categoria)
    {
        Id = id;
        Descricao = descricao;
        Quantidade = quantidade;
        Valor = valor;
        Categoria = categoria;
    }
}
