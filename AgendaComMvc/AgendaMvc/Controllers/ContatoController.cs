using AgendaMvc.Controllers.Dados;
using AgendaMvc.Dao;
using AgendaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using X.PagedList;

namespace AgendaMvc.Controllers
{
   
    public class ContatoController : Controller
    {
        public IActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var contatos = from s in new Dao.DaoContato().consultar()
                           select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                contatos = contatos.Where(s => s.Nome.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    contatos = contatos.OrderByDescending(s => s.Nome);
                    break;
                default:
                    contatos = contatos.OrderBy(s => s.Nome);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(contatos.ToPagedList(pageNumber, pageSize));
            
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
