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
    public class SetoresController : Controller
    {
        private readonly EFContext _contexts = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_contexts.Setores.OrderBy(l => l.Name));
        }

        #region Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(_contexts.Produtos.OrderBy(n => n.Name), "SetorId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Setor Setor)
        {
            _contexts.Setores.Add(Setor);
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

            var Setores = _contexts.Setores.Find(id.Value);

            if (Setores == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.ProdutoId = new SelectList(_contexts.Produtos.OrderBy(n => n.Name), "SetorId", "Name");
            return View(Setors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Setor Setor)
        {
            if (ModelState.IsValid)
            {
                _contexts.Entry(Setor).State = EntityState.Modified;
                _contexts.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Setor);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Setores = _contexts.Setores.Find(id.Value);

            if (Setores == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(Setores);
        }
        #endregion


        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Setor Setor = _contexts.Setores.Find(id.Value);

            if (Setor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(Setor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            Setor Setor = _contexts.Setores.Find(id);
            try
            {
                _contexts.Setores.Remove(Setor);
                _contexts.SaveChanges();
                TempData["Message"] = "Setor " + Setor.Name.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }

            catch
            {

                return View(Setor);
            }

        }
    }
}