namespace EntityProjectNew.Models;

public class Compromisso
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public Contato Contato { get; set; }
    public Local Local { get; set; }
}
