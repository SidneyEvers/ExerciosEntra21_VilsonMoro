namespace AgendaMvc.Models;

public class Compromisso
{
    public int Id{ get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public Contato Contato { get; set; }
    public Locais Local { get; set; }
}
