using AgendaMvc.Dao;
using AgendaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace AgendaMvc.Controllers
{
   
    public class ContatoController : Controller
    {
        
        public IActionResult Index()
        {
            return View(new Dao.DaoContato().consultar());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Contato contato)
        {
            Contato cont = new();
            cont.Id = contato.Id;
            cont.Nome = contato.Nome;
            cont.Email = contato.Email;
            cont.Telefone = contato.Telefone;
            new Dao.DaoContato().salvar(cont);


            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Contato ct = new Dao.DaoContato().consultar((int)id);
            return View(ct);
        }

        [HttpPost]
        public IActionResult Edit(Contato contato)
        {
            Contato contAlt = new Dao.DaoContato().consultar(contato.Id);
            contAlt.Nome = contato.Nome;
            contAlt.Email = contato.Email;
            contAlt.Telefone = contato.Telefone;
            new Dao.DaoContato().alterar(contAlt);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Contato ct = new Dao.DaoContato().Deletar((int)id);
            return View(ct);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int? id)
        {
            Contato contDelete = new Dao.DaoContato().Deletar((int)id);
            new Dao.DaoContato().excluir((int)id);
            return RedirectToAction("Index");
        }

    }
}
