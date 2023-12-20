using EntityProjectNew.Data;
using EntityProjectNew.Models;
using EntityProjectNew.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityProjectNew.Controllers
{
    public class CompromissoController : Controller
    {
        private readonly AppDbContext _context;
        public CompromissoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        // GET: CompromissoController
        public ActionResult Adicionar()
        {
            var locaisDb = _context.Locais.ToList();
            var contatosDb = _context.Contatos.ToList();

            List<Local> locais = new();
            List<Contato> contatos = new();

            foreach(var localItem in locaisDb)
            {
                locais.Add(localItem);
            }
            foreach(var contatoItem in contatosDb)
            {
                contatos.Add(contatoItem);
            }
            var criarCompromissoViewModel = new CriarCompromissoViewModel()
            {
                Locais = locais.Select(x => new SelectListItem { Text = x.Rua, Value = x.Id.ToString() }),
                Contatos = contatos.Select(x => new SelectListItem { Text = x.Nome, Value = x.Id.ToString() })
            };
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public IActionResult Adicionar(CriarCompromissoViewModel criarCompromissoViewModel)
        {
            var local = _context.Locais.FirstOrDefault(x => x.Id == criarCompromissoViewModel.IdLocal);
            var contato = _context.Contatos.FirstOrDefault(x => x.Id == criarCompromissoViewModel.IdContato);

            Compromisso compromisso = new()
            {
                Descricao = criarCompromissoViewModel.Descricao,
                Data = criarCompromissoViewModel.Data,
                Local = local,
                Contato = contato,
            };
            _context.Add(compromisso);
            _context.SaveChanges();
            return RedirectToAction("Listar");
        }

        // GET: CompromissoController/Details/5
        public ActionResult Listar()
        {
            var compromisso = _context.Compromissos.Include(x => x.Local).Include(x => x.Contato).ToList();
            return View(compromisso);
        }

        [HttpGet]
        // GET: CompromissoController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var compromisso = _context.Compromissos.Include(x => x.Local).Include(x => x.Contato).FirstOrDefault(x => x.Id == id);
            var locaisDb = _context.Locais.ToList();
            var contatosDb = _context.Contatos.ToList();

            List<Local> locais = new();
            List<Contato> contatos = new();

            foreach (var localItem in locaisDb)
            {
                locais.Add(localItem);
            }
            foreach (var contatoItem in contatosDb)
            {
                contatos.Add(contatoItem);
            }
            EditarViewModel editarViewModel = new()
            {
                Id = compromisso.Id,
                Descricao = compromisso.Descricao,
                Data = compromisso.Data,
                Locais = locais.Select(x => new SelectListItem { Text = x.Rua, Value = x.Id.ToString() }),
                Contatos = contatos.Select(x => new SelectListItem { Text = x.Nome, Value = x.Id.ToString() }),
                IdLocal = compromisso.Local.Id,
                IdContato = compromisso.Contato.Id,
            };

            return View(editarViewModel);
        }

        // POST: CompromissoController/Edit/5
        [HttpPost]
        public ActionResult Edit(EditarViewModel editarViewModel)
        {
            var compromissos = _context.Compromissos.Include(x => x.Local).Include(x => x.Contato).FirstOrDefault(x => x.Id == editarViewModel.Id);
            var local = _context.Locais.FirstOrDefault(x => x.Id == editarViewModel.IdLocal);
            var contato = _context.Contatos.FirstOrDefault(x => x.Id == editarViewModel.IdContato);

            if (compromissos != null)
            {
                compromissos.Descricao = editarViewModel.Descricao;
                compromissos.Data = editarViewModel.Data;
                compromissos.Local = local;
                compromissos.Contato = contato;
                _context.SaveChanges();
            }
            return RedirectToAction("Listar");

        }

        [HttpGet]
        // GET: CompromissoController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var compromisso = _context.Compromissos.Include(x => x.Local).Include(x => x.Contato).FirstOrDefault(x => x.Id == id);
            var locaisDb = _context.Locais.ToList();
            var contatosDb = _context.Contatos.ToList();

            List<Local> locais = new();
            List<Contato> contatos = new();

            foreach (var localItem in locaisDb)
            {
                locais.Add(localItem);
            }
            foreach (var contatoItem in contatosDb)
            {
                contatos.Add(contatoItem);
            }


            return View(compromisso);
        }

        // POST: CompromissoController/Delete/5
        [HttpPost]

        public ActionResult Delete(Compromisso compromisso)
        {
            var compromissos = _context.Compromissos.Include(x => x.Local).Include(x => x.Contato).ToList();
            foreach(var compromissoItem in compromissos)
            {
                if(compromissoItem.Id == compromisso.Id)
                {
                    _context.Remove(compromissoItem);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Listar");
        }
    }
}
