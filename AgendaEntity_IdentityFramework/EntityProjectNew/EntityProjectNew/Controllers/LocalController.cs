using EntityProjectNew.Data;
using EntityProjectNew.Models.ViewModels;
using EntityProjectNew.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityProjectNew.Controllers
{
    public class LocalController : Controller
    {
        private readonly AppDbContext _context;
        public LocalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LocalController
        [HttpGet]
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(CriarLocalViewModel criarLocalViewModel)
        {
            if (criarLocalViewModel != null)
            {
                var local = new Local()
                {
                    Descricao = criarLocalViewModel.Descricao,
                    Rua = criarLocalViewModel.Rua,
                    Numero = criarLocalViewModel.Numero,
                    Cidade = criarLocalViewModel.Cidade,
                };
                _context.Add(local);
                _context.SaveChanges();
                return RedirectToAction("Listar");
            }
            return View(null);
        }

        // GET: LocalController/Details/5
        public ActionResult Listar()
        {
            var locais = _context.Locais.ToList();
            return View(locais);
        }

        [HttpGet]
        // GET: LocalController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var locais = _context.Locais.FirstOrDefault(x => x.Id == id);

            var novoLocal = new Local()
            {
                Descricao = locais.Descricao,
                Rua = locais.Rua,
                Numero = locais.Numero,
                Cidade = locais.Cidade,
            };
            return View(novoLocal);
        }

        // POST: LocalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Local local)
        {
            var localAntigo = _context.Locais.FirstOrDefault(x => x.Id == local.Id);

            if (localAntigo != null)
            {
                localAntigo.Descricao = local.Descricao;
                localAntigo.Rua = local.Rua;
                localAntigo.Numero = local.Numero;
                localAntigo.Cidade = local.Cidade;

                _context.SaveChanges();
                return RedirectToAction("Listar");
            }

            return View(local);
        }

        // GET: LocalController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var locais = _context.Locais.ToList();
            foreach (var local in locais)
            {
                if (id == local.Id)
                {
                    return View(local);
                }
            }
            return RedirectToAction("Listar");
            
        }

        // POST: LocalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Local local)
        {
            var locais = _context.Locais.ToList();

            foreach (var localItem in locais)
            {
                if (localItem.Id == local.Id)
                {
                    _context.Locais.Remove(localItem);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Listar");
        }
    }
}
