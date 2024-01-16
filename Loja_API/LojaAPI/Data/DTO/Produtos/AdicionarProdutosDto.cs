namespace LojaAPI.Data.DTO.Produtos
{
    public class AdicionarProdutosDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Estoque { get; set; }
        public int Categoria { get; set; }
    }
}
