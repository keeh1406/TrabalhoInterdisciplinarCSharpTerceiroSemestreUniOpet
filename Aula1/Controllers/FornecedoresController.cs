using Aula1.Context;
using Aula1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aula1.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly EFContext _contexts = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_contexts.Fornecedores.OrderBy(l => l.Name));
        }

        #region Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(_contexts.Produtos.OrderBy(n => n.Name), "FornecedorId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fornecedor Fornecedor)
        {
            _contexts.Fornecedores.Add(Fornecedor);
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

            var Fornecedores = _contexts.Fornecedors.Find(id.Value);

            if (Fornecedores == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.ProdutoId = new SelectList(_contexts.Produtos.OrderBy(n => n.Name), "FornecedorId", "Name");
            return View(Fornecedors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Fornecedor Fornecedor)
        {
            if (ModelState.IsValid)
            {
                _contexts.Entry(Fornecedor).State = EntityState.Modified;
                _contexts.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Fornecedor);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Fornecedores = _contexts.Fornecedores.Find(id.Value);

            if (Fornecedores == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(Fornecedores);
        }
        #endregion


        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fornecedor Fornecedor = _contexts.Fornecedores.Find(id.Value);

            if (Fornecedor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(Fornecedor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            Fornecedor Fornecedor = _contexts.Fornecedores.Find(id);
            try
            {
                _contexts.Fornecedores.Remove(Fornecedor);
                _contexts.SaveChanges();
                TempData["Message"] = "Fornecedor " + Fornecedor.Name.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }

            catch
            {

                return View(Fornecedor);
            }

        }
    }
}