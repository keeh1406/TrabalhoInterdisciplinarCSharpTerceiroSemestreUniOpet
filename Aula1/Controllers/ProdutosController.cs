using System;
using Aula1.Context;
using Aula1.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aula1.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly EFContext _contexts = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_contexts
                .Produtos
                .Include(m => m.Marca)
                .Include(s => s.Setor)
                .Include(f => f.Fornecedor)
                .Include(l => l.Loja)
                .OrderBy(p => p.Name));
        }

        #region Create
        public ActionResult Create()
        {
            ViewBag.LojaId = new SelectList(_contexts.Lojas.OrderBy(n => n.Name), "LojaId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            _contexts.Produtos.Add(produto);
            _contexts.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion


        #region Edit
        public ActionResult Edit(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produtos = _contexts.Produtos.Find(id.Value);

            if (produtos == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.LojaId = new SelectList(_contexts.Lojas.OrderBy(n => n.Name), "LojaId", "Name");
            return View(produtos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _contexts.Entry(produto).State = EntityState.Modified;
                _contexts.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = _contexts
                .Produtos
                .Include(p => p.Vendas)
                .Include("Vendas.Cliente")
                .Include(l => l.Loja)
                .First(f => f.ProdutoId == id);

            if (produto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(produto);
        }
        #endregion


        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = _contexts.Produtos.Find(id.Value);

            if (produto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(produto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {

                Produto produto = _contexts.Produtos.Find(id);
                _contexts.Produtos.Remove(produto);
                _contexts.SaveChanges();
                TempData["Message"] = "Produto " + produto.Name.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }

            catch
            {

                return View();
            }

        }
    }
}
