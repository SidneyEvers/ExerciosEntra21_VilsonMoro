using System.Text.Json.Serialization;

namespace LojaAPI_Simplificada.Entities;

public class Produtos
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Valor{ get; set; }
    public int Estoque { get; set; }
    public Categoria Categoria { get; set; }

    [JsonIgnore]
    public int CategoriaId { get; set; }
}
