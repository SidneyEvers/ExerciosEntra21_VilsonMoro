using AgendaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaMvc.Controllers
{
    public class CompromissoController : Controller
    {
        public IActionResult Index()
        {
            return View(Dados.db.compromissos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> contatos = new();
            contatos = Dados.db.contatos.Select(c => new SelectListItem()
            {
                Text = c.Email,
                Value = c.Id.ToString()
            }).ToList();
            ViewBag.contatos = contatos;

            List<SelectListItem> locais = new();
            locais = Dados.db._locais.Select(c => new SelectListItem()
            {
                Text = c.Descricao,
                Value = c.Id.ToString(),
            }).ToList();
            ViewBag.locais = locais;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Compromisso compromisso)
        {
            Compromisso comp = new();
            comp.Descricao = compromisso.Descricao;
            comp.Data = compromisso.Data;
            comp.Contato = Dados.db.contatos.FirstOrDefault(c => c.Id == compromisso.Contato.Id);
            comp.Local = Dados.db._locais.FirstOrDefault(c => c.Id == compromisso.Local.Id);
            Dados.db.compromissos.Add(comp);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Compromisso compromissos= Dados.db.compromissos.FirstOrDefault(ct => ct.Id == id);
            return View(compromissos);
        }

        [HttpPost]
        public IActionResult Edit(Compromisso compromissos)
        {
            Compromisso compAlt = Dados.db.compromissos.FirstOrDefault(ct => ct.Descricao == compromissos.Descricao);
            compAlt.Descricao = compromissos.Descricao;
            compAlt.Data = compromissos.Data;
            compAlt.Contato = compromissos.Contato;
            compAlt.Local.Id = compromissos.Local.Id;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Compromisso compromisso= Dados.db.compromissos.FirstOrDefault(ct => ct.Id == id);
            return View(compromisso);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int? id)
        {
            Compromisso compDelete= Dados.db.compromissos.FirstOrDefault(ct => ct.Id == id);
            Dados.db.compromissos.Remove(compDelete);
            return RedirectToAction("index");
        }
    }
}
