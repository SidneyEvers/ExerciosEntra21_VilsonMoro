namespace LojaAPI.Entities;

public class Produtos
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public int Estoque { get; set; }
    public Categoria Categoria { get; set; }
}
