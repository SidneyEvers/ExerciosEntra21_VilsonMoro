namespace LojaAPI.Data.DTO.Produtos;

public class EditarProdutosDto
{
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public int Estoque { get; set; }
    public int Categoria { get; set; }
}
