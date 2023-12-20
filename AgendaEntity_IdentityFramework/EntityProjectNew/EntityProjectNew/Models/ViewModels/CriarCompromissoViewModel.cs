using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntityProjectNew.Models.ViewModels;

public class CriarCompromissoViewModel
{
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public Guid IdLocal  { get; set; }
    public IEnumerable<SelectListItem?> Locais  { get; set; }
    public Guid IdContato { get; set; }
    public IEnumerable<SelectListItem?> Contatos { get; set; }
}
