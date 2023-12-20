using EntityProjectNew.Data;
using EntityProjectNew.Models;
using EntityProjectNew.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityProjectNew.Controllers
{
    public class ContatoController1 : Controller
    {
        private readonly AppDbContext _context;
        public ContatoController1(AppDbContext context)
        {
            _context = context;
        }
        // GET: ContatoController1
        [HttpGet]
        public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(CriarContatoViewModel criarContatoViewModel)
        {
            if(criarContatoViewModel != null)
            {
                var contato = new Contato()
                {
                    Nome = criarContatoViewModel.Nome,
                    Email = criarContatoViewModel.Email,
                    Telefone = criarContatoViewModel.Telefone,
                };
                _context.Add(contato);
                _context.SaveChanges();
            }
            return RedirectToAction("Listar");

           
        }

        // GET: ContatoController1/Listar/5
        public ActionResult Listar()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        // GET: ContatoController1/Edit/5
        [HttpGet]
        
        public ActionResult Edit(Guid id)
        {
            var contato = _context.Contatos.FirstOrDefault(x => x.Id == id);

            var novoContato = new Contato()
            {
                Nome = contato.Nome,
                Email = contato.Email,
                Telefone = contato.Telefone,
            };
            return View(novoContato);
        }

        // POST: ContatoController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contato contato)
        {
            var contatoAntigo = _context.Contatos.FirstOrDefault(x => x.Id == contato.Id);

            if(contatoAntigo != null)
            {
                contatoAntigo.Nome = contato.Nome;
                contatoAntigo.Email = contato.Email;
                contatoAntigo.Telefone = contato.Telefone;

                _context.SaveChanges();
                return RedirectToAction("Listar");
            }
            
            return View(contato);
        }

        [HttpGet]
        // GET: ContatoController1/Delete/5
        public ActionResult Delete(Guid id)
        {
            var contatos = _context.Contatos.ToList();
            foreach(var contato in contatos)
            {
                if (id == contato.Id)
                {
                    return View(contato);
                }
            }
            return RedirectToAction("Listar");
        }

        // POST: ContatoController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Contato contato)
        {
            var contatos = _context.Contatos.ToList();
            
            foreach(var contatoItem in contatos)
            {
                if(contatoItem.Id == contato.Id)
                {
                    _context.Contatos.Remove(contatoItem);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Listar");
        }
    }
}
