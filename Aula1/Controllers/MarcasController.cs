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
    public class MarcaesController : Controller
    {
        private readonly EFContext _contexts = new EFContext();
        // GET: 
        public ActionResult Index()
        {
            return View(_contexts.Marcas.OrderBy(l => l.Name));
        }

        #region Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(_contexts.Produtos.OrderBy(n => n.Name), "MarcaId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marca Marca)
        {
            _contexts.Marcas.Add(Marca);
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

            var Marcas = _contexts.Marcas.Find(id.Value);

            if (Marcas == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ViewBag.ProdutoId = new SelectList(_contexts.Produtos.OrderBy(n => n.Name), "MarcaId", "Name");
            return View(Marcas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Marca Marca)
        {
            if (ModelState.IsValid)
            {
                _contexts.Entry(Marca).State = EntityState.Modified;
                _contexts.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Marca);

        }
        #endregion


        #region Details
        public ActionResult Details(long? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var Marcas = _contexts.Marcaes.Find(id.Value);

            if (Marcas == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(Marcaes);
        }
        #endregion


        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Marca Marca = _contexts.Marcaes.Find(id.Value);

            if (Marca == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(Marca);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            Marca Marca = _contexts.Marcas.Find(id);
            try
            {
                _contexts.Marcaes.Remove(Marca);
                _contexts.SaveChanges();
                TempData["Message"] = "Marca " + Marca.Name.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }

            catch
            {

                return View(Marca);
            }

        }
    }
}