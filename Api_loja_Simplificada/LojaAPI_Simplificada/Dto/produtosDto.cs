namespace LojaAPI_Simplificada.Dto;

public class produtosDto
{ 
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Valor { get; set; }
    public int Estoque { get; set; }
    public int CategoriaId { get; set; }
}
