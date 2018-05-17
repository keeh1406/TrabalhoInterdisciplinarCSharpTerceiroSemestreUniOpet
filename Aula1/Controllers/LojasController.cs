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
    public class LojasController : Controller
    {
        private readonly EFContext _contexts = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_contexts.Lojas.OrderBy(l => l.Name));
        }

        #region Create
        public ActionResult Create()
        {
            ViewBag.VendaId = new SelectList(_contexts.Vendas.OrderBy(n => n.DescricaoVenda), "ProdutoId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loja loja)
        {
            _contexts.Lojas.Add(loja);
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

            var lojas = _contexts.Lojas.Find(id.Value);

            if (lojas == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.VendaId = new SelectList(_contexts.Vendas.OrderBy(n => n.DescricaoVenda), "ProdutoId", "Name");
            return View(lojas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Loja loja)
        {
            if (ModelState.IsValid)
            {
                _contexts.Entry(loja).State = EntityState.Modified;
                _contexts.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loja); 
            
        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var lojas = _contexts.Lojas.Find(id.Value);

            if (lojas == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(lojas);
        }
        #endregion


        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Loja loja = _contexts.Lojas.Find(id.Value);

            if (loja == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(loja);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            Loja loja = _contexts.Lojas.Find(id);
            try
            {
                _contexts.Lojas.Remove(loja);
                _contexts.SaveChanges();
                TempData["Message"] = "Loja " + loja.Name.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }

            catch
            {

                return View(loja);
            }

        }
    }
}