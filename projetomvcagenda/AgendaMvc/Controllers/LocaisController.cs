using AgendaMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMvc.Controllers
{
    public class LocaisController : Controller
    {
        public IActionResult Index()
        {
            return View(new Dao.DaoLocais().consultar());
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Locais locais)
        {
            Locais local = new();
            local.Id = locais.Id;
            local.Descricao = locais.Descricao;
            local.Rua = locais.Rua;
            local.Numero = locais.Numero;
            local.Cidade = locais.Cidade;
            new Dao.DaoLocais().salvar(local);

            return RedirectToAction("Create");
        }

        public IActionResult Edit(int? id)
        {
            Locais local = Dados.db._locais.FirstOrDefault(ct => ct.Id == id);
            return View(local);
        }

        [HttpPost]
        public IActionResult Edit(Locais local)
        {
            Locais localEdit = Dados.db._locais.FirstOrDefault(ct => ct.Id == local.Id);
            localEdit.Descricao = local.Descricao;
            localEdit.Rua = local.Rua;
            localEdit.Numero = local.Numero;
            localEdit.Cidade = local.Cidade;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Locais local = Dados.db._locais.FirstOrDefault(ct => ct.Id == id);
            return View(local);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int? id)
        {
            Locais localDelete = Dados.db._locais.FirstOrDefault(ct => ct.Id == id);
            Dados.db._locais.Remove(localDelete);
            return RedirectToAction("Index");
        }
    }
}
